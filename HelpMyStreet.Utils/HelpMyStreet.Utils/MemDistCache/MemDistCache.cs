using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Internal;
using Polly.Caching;
using Polly.Contrib.DuplicateRequestCollapser;

namespace HelpMyStreet.Utils.MemDistCache
{
    /// <summary>
    /// A cache with three main features:
    /// 1) If data is stale it will be returned, but fresh data re-cached on a background thread so response times aren't affected.  It is also possible to wait for fresh data though.
    /// 2) If data isn't available in memory, it will check the distributed cache.  This is to prevent re-calculating data if the app pool is reset, shuts down or the application scales out.
    /// 3) A delegate is passed in to calculate when the data will become stale.  This is so all servers' caches can be reset at the same time to avoid inconsistent data.
    /// ISyncCacheProvider, IAsyncCacheProvider and ISystemClock need to be registered in the DI container on startup.
    /// </summary>
    public class MemDistCache : IMemDistCache
    {
        private readonly ISyncCacheProvider _pollySyncCacheProvider;
        private readonly IAsyncCacheProvider _pollyDistributedCacheProvider;
        private readonly ISystemClock _mockableDateTime;

        private static readonly IAsyncRequestCollapserPolicy _collapserPolicy = AsyncRequestCollapserPolicy.Create();
        private static readonly ISyncRequestCollapserPolicy _collapserSyncPolicy = RequestCollapserPolicy.Create();

        private readonly TimeSpan _defaultCacheDuration = new TimeSpan(28, 0, 0, 0);

        public MemDistCache(ISyncCacheProvider pollySyncCacheProvider, IAsyncCacheProvider pollyDistributedCacheProvider, ISystemClock mockableDateTime)
        {
            _pollySyncCacheProvider = pollySyncCacheProvider;
            _pollyDistributedCacheProvider = pollyDistributedCacheProvider;
            _mockableDateTime = mockableDateTime;
        }

        /// <inheritdoc />>
        public async Task<T> GetCachedDataAsync<T>(Func<CancellationToken, Task<T>> dataGetter, string key, CancellationToken cancellationToken, Func<DateTimeOffset, DateTimeOffset> resetTimeDelegate, Action<string, Exception> backendGetErrorDelegate, bool waitForFreshData = false)
        {
            (bool, object) memoryWrappedResult = _pollySyncCacheProvider.TryGet(key);

            bool isObjectInMemoryCache = memoryWrappedResult.Item1;

            if (isObjectInMemoryCache)
            {
                CachedItemWrapper<T> memoryResultObject = (CachedItemWrapper<T>)memoryWrappedResult.Item2;
                bool isMemoryCacheFresh = IsFresh<T>(memoryResultObject);

                if (!isMemoryCacheFresh)
                {
                    if (waitForFreshData)
                    {
                        return await _collapserPolicy.ExecuteAsync(async () => await RecacheItemInMemoryAndDistCacheAsync(dataGetter, key, cancellationToken, resetTimeDelegate, backendGetErrorDelegate));
                    }
                    else
                    {
#pragma warning disable 4014
                        Task.Factory.StartNew(async () => await _collapserPolicy.ExecuteAsync(async () => await RecacheItemInMemoryAndDistCacheAsync(dataGetter, key, cancellationToken, resetTimeDelegate, backendGetErrorDelegate)), cancellationToken);
#pragma warning restore 4014
                    }
                }

                return memoryResultObject.Content;
            }
            else
            {
                (bool, object) distributedCacheWrappedResult = await _pollyDistributedCacheProvider.TryGetAsync(key, cancellationToken, false);

                bool isObjectInDistributedCache = distributedCacheWrappedResult.Item1;

                if (isObjectInDistributedCache)
                {
                    CachedItemWrapper<T> distributedCacheObject = (CachedItemWrapper<T>)distributedCacheWrappedResult.Item2;
                    bool isDistributedCacheFresh = IsFresh<T>(distributedCacheObject);

                    if (isDistributedCacheFresh)
                    {
#pragma warning disable 4014
                            Task.Factory.StartNew(() => _collapserSyncPolicy.Execute(() => AddToMemoryCacheAfterRetrievingFromDistCache(key, distributedCacheObject)), cancellationToken);
#pragma warning restore 4014
                    }
                    else
                    {
                        if (waitForFreshData)
                        {
                            return await _collapserPolicy.ExecuteAsync(async () => await RecacheItemInMemoryAndDistCacheAsync(dataGetter, key, cancellationToken, resetTimeDelegate, backendGetErrorDelegate));
                        }
                        else
                        {
#pragma warning disable 4014
                            Task.Factory.StartNew(() => _collapserPolicy.ExecuteAsync(async () => await RecacheItemInMemoryAndDistCacheAsync(dataGetter, key, cancellationToken, resetTimeDelegate, backendGetErrorDelegate)), cancellationToken);
#pragma warning restore 4014
                        }


                    }

                    return distributedCacheObject.Content;
                }
            }

            // data isn't in either memory or distributed cache
            return await _collapserPolicy.ExecuteAsync(async () => await RecacheItemInMemoryAndDistCacheAsync(dataGetter, key, cancellationToken, resetTimeDelegate, backendGetErrorDelegate));
        }

        private async Task<T> RecacheItemInMemoryAndDistCacheAsync<T>(Func<CancellationToken, Task<T>> dataGetter, string key, CancellationToken cancellationToken, Func<DateTimeOffset, DateTimeOffset> resetTimeDelegate, Action<string, Exception> backendGetErrorDelegate)
        {
            T data;
            try
            {
                data = await dataGetter.Invoke(cancellationToken);
            }
            catch (Exception ex)
            {
                backendGetErrorDelegate.Invoke(key, ex);
                return default(T);
            }

            DateTimeOffset timeToReset = resetTimeDelegate.Invoke(_mockableDateTime.UtcNow);

            Ttl ttl = new Ttl(_defaultCacheDuration);
            CachedItemWrapper<T> itemInWrapper = new CachedItemWrapper<T>(data, timeToReset);

            _pollySyncCacheProvider.Put(key, itemInWrapper, ttl);
            await _pollyDistributedCacheProvider.PutAsync(key, itemInWrapper, ttl, cancellationToken, false);

            return data;
        }

        private void AddToMemoryCacheAfterRetrievingFromDistCache<T>(string key, CachedItemWrapper<T> itemInWrapper)
        {
            Ttl ttl = new Ttl(_defaultCacheDuration);
            _pollySyncCacheProvider.Put(key, itemInWrapper, ttl);
        }

        private bool IsFresh<T>(CachedItemWrapper<T> itemInWrapper)
        {
            if (itemInWrapper.ExpiresAt >= _mockableDateTime.UtcNow)
            {
                return true;
            }
            return false;
        }

        /// <inheritdoc />>
        public async Task<T> GetCachedDataAsync<T>(Func<Task<T>> dataGetter, string key, Func<DateTimeOffset, DateTimeOffset> resetTimeDelegate, Action<string, Exception> backendGetErrorDelegate, bool waitForFreshData = false)
        {
            return await GetCachedDataAsync(token => dataGetter.Invoke(), key, CancellationToken.None, resetTimeDelegate, backendGetErrorDelegate, waitForFreshData);
        }

        /// <inheritdoc />>
        public T GetCachedData<T>(Func<CancellationToken, T> dataGetter, string key, CancellationToken cancellationToken, Func<DateTimeOffset, DateTimeOffset> resetTimeDelegate, Action<string, Exception> backendGetErrorDelegate, bool waitForFreshData = false)
        {
            return GetCachedDataAsync(token => Task.FromResult(dataGetter.Invoke(token)), key, cancellationToken, resetTimeDelegate, backendGetErrorDelegate, waitForFreshData).Result;
        }

        /// <inheritdoc />>
        public T GetCachedData<T>(Func<T> dataGetter, string key, Func<DateTimeOffset, DateTimeOffset> resetTimeDelegate, Action<string, Exception> backendGetErrorDelegate, bool waitForFreshData = false)
        {
            return GetCachedDataAsync(() => Task.FromResult(dataGetter.Invoke()), key, resetTimeDelegate, backendGetErrorDelegate, waitForFreshData).Result;
        }
    }
}
