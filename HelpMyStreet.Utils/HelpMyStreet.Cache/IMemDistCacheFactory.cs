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
        /// <param name="dataGetterErrorDelegate">Use to log an error when getting data from dataGetter delegate</param>
        /// <returns></returns>
        IMemDistCache GetCache(TimeSpan howLongToKeepStaleData, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate, Action<string, Exception> dataGetterErrorDelegate);
    }
}