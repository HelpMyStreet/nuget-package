using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelpMyStreet.Cache
{
    public interface IMemDistCache
    {
        /// <summary>
        ///  Get data from cache. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataGetter">Delegate that return data</param>
        /// <param name="key">The key to store data under</param>
        /// <param name="whenDataIsStaleDelegate">When the data should be considered stale</param>
        /// <param name="waitForFreshData">Whether to wait for fresh data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="dataGetterErrorDelegate">Use to log an error when getting data from dataGetter delegate</param>
        /// <returns></returns>
        Task<T> GetCachedDataAsync<T>(Func<CancellationToken, Task<T>> dataGetter, string key, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate, bool waitForFreshData, CancellationToken cancellationToken, Action<string, Exception> dataGetterErrorDelegate);


        /// <summary>
        ///  Get data from cache. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataGetter">Delegate that return data</param>
        /// <param name="key">The key to store data under</param>
        /// <param name="whenDataIsStaleDelegate">When the data should be considered stale</param>
        /// <param name="waitForFreshData">Whether to wait for fresh data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="dataGetterErrorDelegate">Use to log an error when getting data from dataGetter delegate</param>
        /// <returns></returns>
        T GetCachedData<T>(Func<CancellationToken, T> dataGetter, string key, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate, bool waitForFreshData, CancellationToken cancellationToken, Action<string, Exception> dataGetterErrorDelegate);

    }
}