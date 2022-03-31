using Microsoft.Extensions.Internal;
using Polly.Caching;
using System;
using HelpMyStreet.Utils.Utils;

namespace HelpMyStreet.Cache.MemCache
{
    public class MemCacheFactory<T> : IMemDistCacheFactory<T>
    {
        private readonly ISyncCacheProvider _pollySyncCacheProvider;
        private readonly ISystemClock _mockableDateTime;
        private readonly ILoggerWrapper<MemCache<T>> _logger;

        public MemCacheFactory(ISyncCacheProvider pollySyncCacheProvider, ISystemClock mockableDateTime, ILoggerWrapper<MemCache<T>> logger)
        {
            _pollySyncCacheProvider = pollySyncCacheProvider ?? throw new ArgumentNullException(nameof(pollySyncCacheProvider));
            _mockableDateTime = mockableDateTime ?? throw new ArgumentNullException(nameof(mockableDateTime));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc />>
        public IMemDistCache<T> GetCache(TimeSpan howLongToKeepStaleData, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate)
        {
            MemCache<T> memDistCache = new MemCache<T>(_pollySyncCacheProvider, _mockableDateTime, howLongToKeepStaleData, whenDataIsStaleDelegate, _logger);
            return memDistCache;
        }

    }
}

