using HelpMyStreet.Cache.MemCache;
using HelpMyStreet.Cache.MemDistCache;
using HelpMyStreet.Utils.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Internal;

namespace HelpMyStreet.Cache.Extensions
{
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// Add MemDistCache
        /// </summary>
        public static IServiceCollection AddMemDistCache(this IServiceCollection serviceCollection, string applicationName, string redisConnectionString)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.TryAddSingleton<Polly.Caching.ISyncCacheProvider, Polly.Caching.Memory.MemoryCacheProvider>();

            serviceCollection.AddDistributedRedisCache(options =>
            {
                options.Configuration = redisConnectionString;
                options.InstanceName = applicationName;
            });

            serviceCollection.TryAddSingleton<IDistributedCacheWrapper, DistributedCacheWrapperWithCompression>();
            serviceCollection.TryAddSingleton<ISystemClock, MockableDateTime>();
            serviceCollection.TryAddSingleton<IMemDistCacheFactory, MemDistCacheFactory>();
            serviceCollection.TryAddSingleton<ILoggerWrapper<MemDistCache.MemDistCache>, LoggerWrapper<MemDistCache.MemDistCache>>();

            return serviceCollection;
        }

        /// <summary>
        /// Add in-memory implementation of MemDistCache
        /// </summary>
        public static IServiceCollection AddMemCache(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.TryAddSingleton<Polly.Caching.ISyncCacheProvider, Polly.Caching.Memory.MemoryCacheProvider>();
            serviceCollection.TryAddSingleton<ISystemClock, MockableDateTime>();
            serviceCollection.TryAddSingleton<IMemDistCacheFactory, MemCacheFactory>();
            serviceCollection.TryAddSingleton<ILoggerWrapper<MemCache.MemCache>, LoggerWrapper<MemCache.MemCache>>();

            return serviceCollection;
        }
    }
}
