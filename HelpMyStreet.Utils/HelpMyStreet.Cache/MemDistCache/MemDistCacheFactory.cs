using Microsoft.Extensions.Internal;
using Polly.Caching;
using System;
using HelpMyStreet.Utils.Utils;

namespace HelpMyStreet.Cache.MemDistCache
{
    public class MemDistCacheFactory : IMemDistCacheFactory
    {
        private readonly ISyncCacheProvider _pollySyncCacheProvider;
        private readonly IDistributedCacheWrapper _distributedCacheWrapper;
        private readonly ISystemClock _mockableDateTime;
        private readonly ILoggerWrapper<MemDistCache> _logger;

        public MemDistCacheFactory(ISyncCacheProvider pollySyncCacheProvider, IDistributedCacheWrapper distributedCacheWrapper, ISystemClock mockableDateTime, ILoggerWrapper<MemDistCache> logger)
        {
            _pollySyncCacheProvider = pollySyncCacheProvider;
            _distributedCacheWrapper = distributedCacheWrapper;
            _mockableDateTime = mockableDateTime;
            _logger = logger;
        }

        /// <inheritdoc />>
        public IMemDistCache GetCache(TimeSpan howLongToKeepStaleData, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate)
        {
            MemDistCache memDistCache = new MemDistCache(_pollySyncCacheProvider, _distributedCacheWrapper, _mockableDateTime, howLongToKeepStaleData, whenDataIsStaleDelegate, _logger);
            return memDistCache;
        }
    }
}

