using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelpMyStreet.Cache
{
    public interface IMemDistCache<T>
    {
        /// <summary>
        ///  Get data from cache. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataGetter">Delegate that returns data</param>
        /// <param name="key">The key to store data under</param>
        /// <param name="waitForFreshData">Whether to wait for fresh data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<T> GetCachedDataAsync(Func<CancellationToken, Task<T>> dataGetter, string key, bool waitForFreshData, CancellationToken cancellationToken);


        /// <summary>
        ///  Get data from cache. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataGetter">Delegate that returns data</param>
        /// <param name="key">The key to store data under</param>
        /// <param name="waitForFreshData">Whether to wait for fresh data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        T GetCachedData(Func<CancellationToken, T> dataGetter, string key, bool waitForFreshData, CancellationToken cancellationToken);

    }
}