using Microsoft.Extensions.Internal;
using Polly.Caching;
using System;
using HelpMyStreet.Utils.Utils;

namespace HelpMyStreet.Cache.MemCache
{
    public class MemCacheFactory : IMemDistCacheFactory
    {
        private readonly ISyncCacheProvider _pollySyncCacheProvider;
        private readonly ISystemClock _mockableDateTime;
        private readonly ILoggerWrapper<MemCache> _logger;

        public MemCacheFactory(ISyncCacheProvider pollySyncCacheProvider, ISystemClock mockableDateTime, ILoggerWrapper<MemCache> logger)
        {
            _pollySyncCacheProvider = pollySyncCacheProvider;
            _mockableDateTime = mockableDateTime;
            _logger = logger;
        }

        /// <inheritdoc />>
        public IMemDistCache GetCache(TimeSpan howLongToKeepStaleData, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate)
        {
            MemCache memDistCache = new MemCache(_pollySyncCacheProvider, _mockableDateTime, howLongToKeepStaleData, whenDataIsStaleDelegate, _logger);
            return memDistCache;
        }

    }
}

