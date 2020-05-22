﻿using HelpMyStreet.Cache.MemDistCache;
using HelpMyStreet.Utils.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Internal;

namespace HelpMyStreet.Cache.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static  IServiceCollection AddMemDistCache(this IServiceCollection serviceCollection, string applicationName, string redisConnectionString)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<Polly.Caching.ISyncCacheProvider, Polly.Caching.Memory.MemoryCacheProvider>();

            serviceCollection.AddDistributedRedisCache(options =>
            {
                options.Configuration = redisConnectionString; 
                options.InstanceName = applicationName;
            });

            serviceCollection.AddSingleton<IDistributedCacheWrapper, DistributedCacheWrapperWithCompression>();
            serviceCollection.AddSingleton<ISystemClock, MockableDateTime>();
            serviceCollection.AddSingleton<MemDistCache.MemDistCache>();

            return serviceCollection;
        }
    }
}