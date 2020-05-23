using System;

namespace HelpMyStreet.Cache
{
    public interface IMemDistCacheFactory
    {
        /// <summary>
        /// Get cache
        /// </summary>
        /// <param name="howLongToKeepStaleData">How long to keep stale data in the cache</param>
        /// <param name="whenDataIsStaleDelegate">When the data should be considered stale</param> 
        /// <returns></returns>
        IMemDistCache GetCache(TimeSpan howLongToKeepStaleData, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate);
    }
}