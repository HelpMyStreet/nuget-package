﻿using HelpMyStreet.Cache.Models;
using Microsoft.Extensions.Internal;
using Polly;
using Polly.Caching;
using Polly.Contrib.DuplicateRequestCollapser;
using System;
using System.Threading;
using System.Threading.Tasks;
using HelpMyStreet.Utils.Utils;

namespace HelpMyStreet.Cache.MemCache
{
    /// <summary>
    /// A cache with these features:
    /// 1) If data is stale it will be returned, but fresh data is re-cached on a background thread so response times aren't affected.  It is also possible to wait for fresh data.
    /// 2) A delegate is passed in to calculate when the data will become stale.  This is so all servers' caches are reset at the same time to avoid inconsistent data.
    /// 3) Concurrent requests for the same key will result in only one call to the data getter delegate.
    /// Set up in DI container using: services.AddMemDistCache()
    /// </summary>
    public class MemCache<T> : IMemDistCache<T>
    {
        private readonly ISyncCacheProvider _pollySyncCacheProvider;
        private readonly ISystemClock _mockableDateTime;

        private static readonly IAsyncRequestCollapserPolicy _collapserPolicy = AsyncRequestCollapserPolicy.Create();

        private readonly TimeSpan _defaultCacheDuration;
        private readonly Func<DateTimeOffset, DateTimeOffset> _defaultWhenDataIsStaleDelegate;
        private readonly ILoggerWrapper<MemCache<T>> _logger;

        public MemCache(ISyncCacheProvider pollySyncCacheProvider, ISystemClock mockableDateTime, TimeSpan defaultCacheDuration, Func<DateTimeOffset, DateTimeOffset> defaultWhenDataIsStaleDelegate, ILoggerWrapper<MemCache<T>> logger)
        {
            _pollySyncCacheProvider = pollySyncCacheProvider ?? throw new ArgumentNullException(nameof(pollySyncCacheProvider));
            _mockableDateTime = mockableDateTime ?? throw new ArgumentNullException(nameof(mockableDateTime));
            _defaultCacheDuration = defaultCacheDuration;
            _defaultWhenDataIsStaleDelegate = defaultWhenDataIsStaleDelegate ?? throw new ArgumentNullException(nameof(defaultWhenDataIsStaleDelegate));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc />>
        public async Task<CachedItemWrapper<T>> GetCachedDataInWrapperAsync(Func<CancellationToken, Task<T>> dataGetter, string key, RefreshBehaviour refreshBehaviour, CancellationToken cancellationToken, NotInCacheBehaviour notInCacheBehaviour, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate)
        {
            whenDataIsStaleDelegate = whenDataIsStaleDelegate ?? _defaultWhenDataIsStaleDelegate;

            (bool, object) memoryWrappedResult = _pollySyncCacheProvider.TryGet(key);

            bool isObjectInMemoryCache = memoryWrappedResult.Item1;

            if (isObjectInMemoryCache)
            {
                CachedItemWrapper<T> memoryResultObject = (CachedItemWrapper<T>)memoryWrappedResult.Item2;
                bool isMemoryCacheFresh = IsFresh(memoryResultObject);

                if (!isMemoryCacheFresh)
                {
                    if (refreshBehaviour == RefreshBehaviour.WaitForFreshData)
                    {
                        return await _collapserPolicy.ExecuteAsync(async () => await RecacheItemInMemoryCacheAsync(dataGetter, key, cancellationToken, whenDataIsStaleDelegate));
                    }
                    else if (refreshBehaviour == RefreshBehaviour.DontWaitForFreshData)
                    {
#pragma warning disable 4014
                        Task.Factory.StartNew(async () => await RecacheItemInMemoryCacheAsync(dataGetter, key, cancellationToken, whenDataIsStaleDelegate), cancellationToken);
#pragma warning restore 4014
                    }
                }

                return memoryResultObject;
            }

            if (notInCacheBehaviour == NotInCacheBehaviour.WaitForData)
            {
                return await RecacheItemInMemoryCacheAsync(dataGetter, key, cancellationToken, whenDataIsStaleDelegate);
            }
            else if (notInCacheBehaviour == NotInCacheBehaviour.DontWaitForData)
            {
#pragma warning disable 4014
                Task.Factory.StartNew(async () => await RecacheItemInMemoryCacheAsync(dataGetter, key, cancellationToken, whenDataIsStaleDelegate), cancellationToken);
#pragma warning restore 4014
            }

            return new CachedItemWrapper<T>(default, DateTime.MinValue);
        }

        private async Task<CachedItemWrapper<T>> RecacheItemInMemoryCacheAsync(Func<CancellationToken, Task<T>> dataGetter, string key, CancellationToken cancellationToken, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate)
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
                    _logger.LogError($"Error executing data getter for key: {key}", ex);
                    return default;
                }

                DateTimeOffset timeToReset = whenDataIsStaleDelegate.Invoke(_mockableDateTime.UtcNow);

                Ttl ttl = new Ttl(_defaultCacheDuration);
                CachedItemWrapper<T> itemInWrapper = new CachedItemWrapper<T>(data, timeToReset);

                _pollySyncCacheProvider.Put(key, itemInWrapper, ttl);

                return itemInWrapper;


            }, new Context(key), cancellationToken);
        }

        private bool IsFresh(CachedItemWrapper<T> itemInWrapper)
        {
            if (itemInWrapper.IsFreshUntil >= _mockableDateTime.UtcNow)
            {
                return true;
            }
            return false;
        }

        /// <inheritdoc />>
        public async Task<T> RefreshDataAsync(Func<CancellationToken, Task<T>> dataGetter, string key, CancellationToken cancellationToken, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate)
        {
            var itemInWrapper = await RecacheItemInMemoryCacheAsync(dataGetter, key, cancellationToken, whenDataIsStaleDelegate ?? _defaultWhenDataIsStaleDelegate);
            return itemInWrapper.Content;
        }

        /// <inheritdoc />>
        public CachedItemWrapper<T> GetCachedDataInWrapper(Func<CancellationToken, T> dataGetter, string key, RefreshBehaviour refreshBehaviour, CancellationToken cancellationToken, NotInCacheBehaviour notInCacheBehaviour, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate)
        {
            return GetCachedDataInWrapperAsync(token => Task.FromResult(dataGetter.Invoke(token)), key, refreshBehaviour, cancellationToken, notInCacheBehaviour, whenDataIsStaleDelegate).Result;
        }

        /// <inheritdoc />>
        public T GetCachedData(Func<CancellationToken, T> dataGetter, string key, RefreshBehaviour refreshBehaviour, CancellationToken cancellationToken, NotInCacheBehaviour notInCacheBehaviour, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate)
        {
            return GetCachedDataAsync(token => Task.FromResult(dataGetter.Invoke(token)), key, refreshBehaviour, cancellationToken, notInCacheBehaviour, whenDataIsStaleDelegate).Result;
        }

        /// <inheritdoc />>
        public async Task<T> GetCachedDataAsync(Func<CancellationToken, Task<T>> dataGetter, string key, RefreshBehaviour refreshBehaviour, CancellationToken cancellationToken, NotInCacheBehaviour notInCacheBehaviour = NotInCacheBehaviour.WaitForData, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate = null)
        {
            var itemInWrapper = await GetCachedDataInWrapperAsync(dataGetter, key, refreshBehaviour, cancellationToken, notInCacheBehaviour, whenDataIsStaleDelegate);
            return itemInWrapper.Content;
        }
    }
}
