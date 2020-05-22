using System;
using System.Threading;
using System.Threading.Tasks;
using HelpMyStreet.Cache.Models;
using Microsoft.Extensions.Internal;
using Polly;
using Polly.Caching;
using Polly.Contrib.DuplicateRequestCollapser;

namespace HelpMyStreet.Cache.MemDistCache
{

    /// <summary>
    /// A cache with three main features:
    /// 1) If data is stale it will be returned, but fresh data re-cached on a background thread so response times aren't affected.  It is also possible to wait for fresh data.
    /// 2) If data isn't available in memory, it will check the distributed cache.  This is to prevent re-calculating data if the app pool is reset, shuts down or the application scales out.
    /// 3) A delegate is passed in to calculate when the data will become stale.  This is so all servers' caches can be reset at the same time to avoid inconsistent data.
    /// Set up in DI container using: services.AddMemDistCache()
    /// </summary>
    public class MemDistCache : IMemDistCache
    {
        private readonly ISyncCacheProvider _pollySyncCacheProvider;
        private readonly IDistributedCacheWrapper _pollyDistributedCacheProvider;
        private readonly ISystemClock _mockableDateTime;

        private static readonly IAsyncRequestCollapserPolicy _collapserPolicy = AsyncRequestCollapserPolicy.Create();
        private static readonly ISyncRequestCollapserPolicy _collapserSyncPolicy = RequestCollapserPolicy.Create();

        private readonly TimeSpan _defaultCacheDuration = new TimeSpan(28, 0, 0, 0);

        public MemDistCache(ISyncCacheProvider pollySyncCacheProvider, IDistributedCacheWrapper pollyDistributedCacheProvider, ISystemClock mockableDateTime)
        {
            _pollySyncCacheProvider = pollySyncCacheProvider;
            _pollyDistributedCacheProvider = pollyDistributedCacheProvider;
            _mockableDateTime = mockableDateTime;
        }

        /// <inheritdoc />>
        public async Task<T> GetCachedDataAsync<T>(Func<CancellationToken, Task<T>> dataGetter, string key, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate, bool waitForFreshData, CancellationToken cancellationToken, Action<string, Exception> backendGetErrorDelegate)
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
                        return await _collapserPolicy.ExecuteAsync(async () => await RecacheItemInMemoryAndDistCacheAsync(dataGetter, key, cancellationToken, whenDataIsStaleDelegate, backendGetErrorDelegate));
                    }
                    else
                    {
#pragma warning disable 4014
                        Task.Factory.StartNew(async () => await RecacheItemInMemoryAndDistCacheAsync(dataGetter, key, cancellationToken, whenDataIsStaleDelegate, backendGetErrorDelegate), cancellationToken);
#pragma warning restore 4014
                    }
                }

                return memoryResultObject.Content;
            }
            else
            {
                (bool, object) distributedCacheWrappedResult = await _pollyDistributedCacheProvider.TryGetAsync<CachedItemWrapper<T>>(key, cancellationToken, false);

                bool isObjectInDistributedCache = distributedCacheWrappedResult.Item1;

                if (isObjectInDistributedCache)
                {
                    CachedItemWrapper<T> distributedCacheObject = (CachedItemWrapper<T>)distributedCacheWrappedResult.Item2;
                    bool isDistributedCacheFresh = IsFresh<T>(distributedCacheObject);

                    if (isDistributedCacheFresh)
                    {
                        AddToMemoryCache(key, distributedCacheObject);
                    }
                    else
                    {
                        if (waitForFreshData)
                        {
                            return await RecacheItemInMemoryAndDistCacheAsync(dataGetter, key, cancellationToken, whenDataIsStaleDelegate, backendGetErrorDelegate);
                        }
                        else
                        {
#pragma warning disable 4014
                            Task.Factory.StartNew(async () => await RecacheItemInMemoryAndDistCacheAsync(dataGetter, key, cancellationToken, whenDataIsStaleDelegate, backendGetErrorDelegate), cancellationToken);
#pragma warning restore 4014
                        }
                    }

                    return distributedCacheObject.Content;
                }
            }

            // data isn't in either memory or distributed cache
            return await RecacheItemInMemoryAndDistCacheAsync(dataGetter, key, cancellationToken, whenDataIsStaleDelegate, backendGetErrorDelegate);
        }

        private async Task<T> RecacheItemInMemoryAndDistCacheAsync<T>(Func<CancellationToken, Task<T>> dataGetter, string key, CancellationToken cancellationToken, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate, Action<string, Exception> backendGetErrorDelegate)
        {
            return await _collapserPolicy.ExecuteAsync(async (context, token) =>
            {
                T data;
                try
                {
                    data = await dataGetter.Invoke(cancellationToken);
                }
                catch (Exception ex)
                {
                    backendGetErrorDelegate?.Invoke(key, ex);
                    return default(T);
                }

                DateTimeOffset timeToReset = whenDataIsStaleDelegate.Invoke(_mockableDateTime.UtcNow);

                Ttl ttl = new Ttl(_defaultCacheDuration);
                CachedItemWrapper<T> itemInWrapper = new CachedItemWrapper<T>(data, timeToReset);

                _pollySyncCacheProvider.Put(key, itemInWrapper, ttl);
                await _pollyDistributedCacheProvider.PutAsync(key, itemInWrapper, ttl, cancellationToken, false);

                return data;


            }, new Context(key), cancellationToken);
        }

        private void AddToMemoryCache<T>(string key, CachedItemWrapper<T> itemInWrapper)
        {
            _collapserSyncPolicy.Execute((context) =>
            {
                Ttl ttl = new Ttl(_defaultCacheDuration);
                _pollySyncCacheProvider.Put(key, itemInWrapper, ttl);
            }, new Context(key));
        }

        private bool IsFresh<T>(CachedItemWrapper<T> itemInWrapper)
        {
            if (itemInWrapper.IsFreshUntil >= _mockableDateTime.UtcNow)
            {
                return true;
            }
            return false;
        }

        /// <inheritdoc />>
        public T GetCachedData<T>(Func<CancellationToken, T> dataGetter, string key, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate, bool waitForFreshData, CancellationToken cancellationToken, Action<string, Exception> backendGetErrorDelegate)
        {
            return GetCachedDataAsync(token => Task.FromResult(dataGetter.Invoke(token)), key, whenDataIsStaleDelegate, waitForFreshData, cancellationToken, backendGetErrorDelegate).Result;
        }

    }
}
