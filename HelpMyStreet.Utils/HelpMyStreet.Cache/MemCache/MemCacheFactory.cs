using Microsoft.Extensions.Internal;
using Polly.Caching;
using System;

namespace HelpMyStreet.Cache.MemCache
{
    public class MemCacheFactory : IMemDistCacheFactory
    {
        private readonly ISyncCacheProvider _pollySyncCacheProvider;
        private readonly ISystemClock _mockableDateTime;

        public MemCacheFactory(ISyncCacheProvider pollySyncCacheProvider, ISystemClock mockableDateTime)
        {
            _pollySyncCacheProvider = pollySyncCacheProvider;
            _mockableDateTime = mockableDateTime;
        }

        /// <inheritdoc />>
        public IMemDistCache GetCache(TimeSpan howLongToKeepStaleData, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate, Action<string, Exception> dataGetterErrorDelegate)
        {
            MemCache memDistCache = new MemCache(_pollySyncCacheProvider, _mockableDateTime, howLongToKeepStaleData, whenDataIsStaleDelegate, dataGetterErrorDelegate);
            return memDistCache;
        }

    }
}

