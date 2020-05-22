using HelpMyStreet.Cache;
using HelpMyStreet.Cache.Extensions;
using HelpMyStreet.Cache.MemDistCache;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Internal;
using NUnit.Framework;
using Polly.Caching;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelpMyStreet.UnitTests
{
    public class RandomTests
    {
        [Test]
        public async Task Test()
        {

            ServiceCollection services = new ServiceCollection();

            //services.AddMemoryCache();
            //services.AddSingleton<Polly.Caching.ISyncCacheProvider, Polly.Caching.Memory.MemoryCacheProvider>();



            //services.AddSingleton<IDistributedCacheWrapper, DistributedCacheWrapperWithCompression>();
            //services.AddSingleton<ISystemClock, MockableDateTime>();
            //services.AddSingleton<MemDistCache>();

            

           // services.AddMemCache();

            var serviceProvider = services.BuildServiceProvider();

            var aa = serviceProvider.GetService<ISyncCacheProvider>();
            var bbCache = serviceProvider.GetService<IAsyncCacheProvider>();
            var cc = serviceProvider.GetService<ISystemClock>();
            var dddcc = serviceProvider.GetService<IDistributedCacheWrapper>();
            var regerg = serviceProvider.GetService<IDistributedCache>();

           // var eff = regerg.Get("gg");

            var cache = serviceProvider.GetService<IMemDistCache>();

            var testClass = new TestClass()
            {
                Property = "hello"
            };

            Func<CancellationToken, Task<TestClass>> dataGetter = token => {

                var res = new TestClass()
                {
                    Property = "hello"
                };

                return Task.FromResult(res);
            };

            var result = await cache.GetCachedDataAsync(dataGetter, "key2", TimeLengths.OnHour, false, CancellationToken.None, (s, exception) => { });
            var result2 = await cache.GetCachedDataAsync(dataGetter, "key2", TimeLengths.OnHour, false, CancellationToken.None, (s, exception) => { });
        }
    }

 




}
