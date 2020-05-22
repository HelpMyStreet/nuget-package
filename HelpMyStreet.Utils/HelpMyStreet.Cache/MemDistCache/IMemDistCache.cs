using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelpMyStreet.Cache.MemDistCache
{

    public interface IMemDistCache
    {
        /// <summary>
        ///  Get data from cache. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataGetter">Delegate that return data</param>
        /// <param name="key">The key to store data under</param>
        /// <param name="whenDataIsStaleDelegate"></param>
        /// <param name="waitForFreshData"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="backendGetErrorDelegate"></param>
        /// <param name="resetCacheTime">When cache should reset</param>
        /// <returns></returns>
        Task<T> GetCachedDataAsync<T>(Func<CancellationToken, Task<T>> dataGetter, string key, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate, bool waitForFreshData, CancellationToken cancellationToken, Action<string, Exception> backendGetErrorDelegate);


        /// <summary>
        ///  Get data from cache. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataGetter">Delegate that return data</param>
        /// <param name="key">The key to store data under</param>
        /// <param name="whenDataIsStaleDelegate"></param>
        /// <param name="waitForFreshData"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="backendGetErrorDelegate"></param>
        /// <param name="resetCacheTime">When cache should reset</param>
        /// <returns></returns>
        T GetCachedData<T>(Func<CancellationToken, T> dataGetter, string key, Func<DateTimeOffset, DateTimeOffset> whenDataIsStaleDelegate, bool waitForFreshData, CancellationToken cancellationToken, Action<string, Exception> backendGetErrorDelegate);

    }
}