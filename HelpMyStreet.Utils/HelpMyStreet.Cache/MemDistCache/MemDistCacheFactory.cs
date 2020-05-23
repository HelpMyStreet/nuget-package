using Microsoft.Extensions.Internal;
using Polly.Caching;
using System;

namespace HelpMyStreet.Cache.MemDistCache
{
    public class MemDistCacheFactory : IMemDistCacheFactory
    {
        private readonly ISyncCacheProvider _pollySyncCacheProvider;
        private readonly IDistributedCacheWrapper _distributedCacheWrapper;
        private readonly ISystemClock _mockableDateTime;

        public MemDistCacheFactory(ISyncCacheProvider pollySyncCacheProvider, IDistributedCacheWrapper distributedCacheWrapper, ISystemClock mockableDateTime)
        {
            _pollySyncCacheProvider = pollySyncCacheProvider;
            _distributedCacheWrapper = distributedCacheWrapper;
            _mockableDateTime = mockableDateTime;
        }

        /// <inheritdoc />>
        public IMemDistCache GetCache(TimeSpan howLongToKeepStaleData, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate, Action<string, Exception> dataGetterErrorDelegate)
        {
            MemDistCache memDistCache = new MemDistCache(_pollySyncCacheProvider, _distributedCacheWrapper, _mockableDateTime, howLongToKeepStaleData, whenDataIsStaleDelegate, dataGetterErrorDelegate);
            return memDistCache;
        }
    }
}

