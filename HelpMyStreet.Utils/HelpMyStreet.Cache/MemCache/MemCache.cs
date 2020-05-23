using HelpMyStreet.Cache.Models;
using Microsoft.Extensions.Internal;
using Polly;
using Polly.Caching;
using Polly.Contrib.DuplicateRequestCollapser;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelpMyStreet.Cache.MemCache
{
    /// <summary>
    /// A cache with these features:
    /// 1) If data is stale it will be returned, but fresh data is re-cached on a background thread so response times aren't affected.  It is also possible to wait for fresh data.
    /// 2) A delegate is passed in to calculate when the data will become stale.  This is so all servers' caches are reset at the same time to avoid inconsistent data.
    /// 3) Concurrent requests for the same key will result in only one call to the data getter delegate.
    /// Set up in DI container using: services.AddMemDistCache()
    /// </summary>
    public class MemCache : IMemDistCache
    {
        private readonly ISyncCacheProvider _pollySyncCacheProvider;
        private readonly ISystemClock _mockableDateTime;

        private static readonly IAsyncRequestCollapserPolicy _collapserPolicy = AsyncRequestCollapserPolicy.Create();

        private readonly TimeSpan _defaultCacheDuration;
        private readonly Func<DateTimeOffset, DateTimeOffset> _whenDataIsStaleDelegate;
        private readonly Action<string, Exception> _dataGetterErrorDelegate;

        public MemCache(ISyncCacheProvider pollySyncCacheProvider, ISystemClock mockableDateTime, TimeSpan defaultCacheDuration, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate, Action<string, Exception> dataGetterErrorDelegate)
        {
            _pollySyncCacheProvider = pollySyncCacheProvider;
            _mockableDateTime = mockableDateTime;
            _defaultCacheDuration = defaultCacheDuration;
            _whenDataIsStaleDelegate = whenDataIsStaleDelegate;
            _dataGetterErrorDelegate = dataGetterErrorDelegate;
        }

        /// <inheritdoc />>
        public async Task<T> GetCachedDataAsync<T>(Func<CancellationToken, Task<T>> dataGetter, string key, bool waitForFreshData, CancellationToken cancellationToken)
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
                        return await _collapserPolicy.ExecuteAsync(async () => await RecacheItemInMemoryCacheAsync(dataGetter, key, cancellationToken, _whenDataIsStaleDelegate, _dataGetterErrorDelegate));
                    }
                    else
                    {
#pragma warning disable 4014
                        Task.Factory.StartNew(async () => await RecacheItemInMemoryCacheAsync(dataGetter, key, cancellationToken, _whenDataIsStaleDelegate, _dataGetterErrorDelegate), cancellationToken);
#pragma warning restore 4014
                    }
                }

                return memoryResultObject.Content;
            }

            return await RecacheItemInMemoryCacheAsync(dataGetter, key, cancellationToken, _whenDataIsStaleDelegate, _dataGetterErrorDelegate);
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
        public T GetCachedData<T>(Func<CancellationToken, T> dataGetter, string key, bool waitForFreshData, CancellationToken cancellationToken)
        {
            return GetCachedDataAsync(token => Task.FromResult(dataGetter.Invoke(token)), key, waitForFreshData, cancellationToken).Result;
        }

    }
}
