using System;
using System.Threading;
using System.Threading.Tasks;
using HelpMyStreet.Cache.MemDistCache;
using HelpMyStreet.Cache.Models;
using Microsoft.Extensions.Internal;
using Polly;
using Polly.Caching;
using Polly.Contrib.DuplicateRequestCollapser;

namespace HelpMyStreet.Cache.MemCache
{
    /// <summary>
    /// A cache with two main features:
    /// 1) If data is stale it will be returned, but fresh data re-cached on a background thread so response times aren't affected.  It is also possible to wait for fresh data.
    /// 2) A delegate is passed in to calculate when the data will become stale.  This is so all servers' caches can be reset at the same time to avoid inconsistent data.
    /// Set up in DI container using: services.AddMemCache()
    /// </summary>
    public class MemCache : IMemDistCache
    {
        private readonly ISyncCacheProvider _pollySyncCacheProvider;
        private readonly ISystemClock _mockableDateTime;

        private static readonly IAsyncRequestCollapserPolicy _collapserPolicy = AsyncRequestCollapserPolicy.Create();

        private readonly TimeSpan _defaultCacheDuration = new TimeSpan(28, 0, 0, 0);

        public MemCache(ISyncCacheProvider pollySyncCacheProvider, ISystemClock mockableDateTime)
        {
            _pollySyncCacheProvider = pollySyncCacheProvider;
            _mockableDateTime = mockableDateTime;
        }

        /// <inheritdoc />>
        public async Task<T> GetCachedDataAsync<T>(Func<CancellationToken, Task<T>> dataGetter, string key, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate, bool waitForFreshData, CancellationToken cancellationToken, Action<string, Exception> dataGetterErrorDelegate)
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
                        return await _collapserPolicy.ExecuteAsync(async () => await RecacheItemInMemoryCacheAsync(dataGetter, key, cancellationToken, whenDataIsStaleDelegate, dataGetterErrorDelegate));
                    }
                    else
                    {
#pragma warning disable 4014
                        Task.Factory.StartNew(async () => await RecacheItemInMemoryCacheAsync(dataGetter, key, cancellationToken, whenDataIsStaleDelegate, dataGetterErrorDelegate), cancellationToken);
#pragma warning restore 4014
                    }
                }

                return memoryResultObject.Content;
            }
           
            return await RecacheItemInMemoryCacheAsync(dataGetter, key, cancellationToken, whenDataIsStaleDelegate, dataGetterErrorDelegate);
        }

        private async Task<T> RecacheItemInMemoryCacheAsync<T>(Func<CancellationToken, Task<T>> dataGetter, string key, CancellationToken cancellationToken, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate, Action<string, Exception> backendGetErrorDelegate)
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

                return data;


            }, new Context(key), cancellationToken);
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
        public T GetCachedData<T>(Func<CancellationToken, T> dataGetter, string key, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate, bool waitForFreshData, CancellationToken cancellationToken, Action<string, Exception> dataGetterErrorDelegate)
        {
            return GetCachedDataAsync(token => Task.FromResult(dataGetter.Invoke(token)), key, whenDataIsStaleDelegate, waitForFreshData, cancellationToken, dataGetterErrorDelegate).Result;
        }

    }
}
