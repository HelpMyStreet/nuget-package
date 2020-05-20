using HelpMyStreet.Utils.MemDistCache;
using Microsoft.Extensions.Internal;
using Moq;
using NUnit.Framework;
using Polly.Caching;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelpMyStreet.UnitTests
{
    public class MemDistCacheTests
    {
        private Mock<ISyncCacheProvider> _pollySyncCacheProvider;
        private Mock<IAsyncCacheProvider> _pollydistributedCacheProvider;
        private Mock<ISystemClock> _mockableDateTime;

        private int _numberOfTimesDataGetterDelegate1Called;
        private Func<CancellationToken, Task<string>> _dataGetterDelegate1;

        private int _backendGetErrorDelegateTimesCalled;
        private Action<string, Exception> _backendGetErrorDelegate;
        
        private int _waitForBackgroundThreadToCompleteMs = 100;

        private readonly TimeSpan _defaultCacheDuration = new TimeSpan(28, 0, 0, 0);

        [SetUp]
        public void SetUp()
        {
            _numberOfTimesDataGetterDelegate1Called = 0;
            _dataGetterDelegate1 = async (token) =>
            {
                Interlocked.Increment(ref _numberOfTimesDataGetterDelegate1Called);
                await Task.Delay(25);
                return await Task.FromResult("dataFromBackendGet");
            };

            _mockableDateTime = new Mock<ISystemClock>();
            
            _pollySyncCacheProvider = new Mock<ISyncCacheProvider>();

            _pollySyncCacheProvider.Setup(x => x.TryGet(It.IsAny<string>()));
            _pollySyncCacheProvider.Setup(x => x.Put(It.IsAny<string>(), It.IsAny<CachedItemWrapper<string>>(), It.IsAny<Ttl>()));
            
            _pollydistributedCacheProvider = new Mock<IAsyncCacheProvider>();
            _pollydistributedCacheProvider.Setup(x => x.TryGetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>(), It.IsAny<bool>()));
            _pollydistributedCacheProvider.Setup(x => x.PutAsync(It.IsAny<string>(), It.IsAny<CachedItemWrapper<string>>(), It.IsAny<Ttl>(), It.IsAny<CancellationToken>(), It.IsAny<bool>()));

            _backendGetErrorDelegateTimesCalled = 0;
            _backendGetErrorDelegate = (s, exception) =>
            {
                _backendGetErrorDelegateTimesCalled++;
            };
        }

        [Test]
        public async Task DataInMemoryCacheAndFresh()
        {
            CachedItemWrapper<string> memoryCacheItem = new CachedItemWrapper<string>("fromMemCache", new DateTimeOffset(2020, 05, 17, 20, 00, 00, 00, new TimeSpan(0, 0, 0)));

            _pollySyncCacheProvider.Setup(x => x.TryGet(It.IsAny<string>())).Returns((true,memoryCacheItem));

            _mockableDateTime.Setup(x => x.UtcNow).Returns(new DateTimeOffset(2020, 05, 17, 20, 00, 00, 00, new TimeSpan(0, 0, 0)));

            MemDistCache inMemDistCache = new MemDistCache(_pollySyncCacheProvider.Object, _pollydistributedCacheProvider.Object, _mockableDateTime.Object);

            string result = await inMemDistCache.GetCachedDataAsync(_dataGetterDelegate1, "key", CancellationToken.None, ResetTimes.OnHour, _backendGetErrorDelegate);


            Assert.AreEqual("fromMemCache", result);
            Assert.AreEqual(0, _numberOfTimesDataGetterDelegate1Called);

            _pollySyncCacheProvider.Verify(x => x.TryGet(It.IsAny<string>()), Times.Once);
            _pollySyncCacheProvider.Verify(x => x.Put(It.IsAny<string>(), It.IsAny<CachedItemWrapper<string>>(), It.IsAny<Ttl>()), Times.Never);

            _pollydistributedCacheProvider.Verify(x => x.TryGetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Never);
            _pollydistributedCacheProvider.Verify(x => x.PutAsync(It.IsAny<string>(), It.IsAny<CachedItemWrapper<string>>(), It.IsAny<Ttl>(), It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Never);
        }

        [Test]
        public async Task DataInMemoryCacheButNotFresh()
        {
            CachedItemWrapper<string> memoryCacheItem = new CachedItemWrapper<string>("fromMemCache", new DateTimeOffset(2020, 05, 17, 19, 59, 59, 00, new TimeSpan(0, 0, 0)));

            _pollySyncCacheProvider.Setup(x => x.TryGet(It.IsAny<string>())).Returns((true, memoryCacheItem));

            _mockableDateTime.Setup(x => x.UtcNow).Returns(new DateTimeOffset(2020, 05, 17, 20, 00, 00, 00, new TimeSpan(0, 0, 0)));

            MemDistCache inMemDistCache = new MemDistCache(_pollySyncCacheProvider.Object, _pollydistributedCacheProvider.Object, _mockableDateTime.Object);

            string result = await inMemDistCache.GetCachedDataAsync(_dataGetterDelegate1, "key", CancellationToken.None, ResetTimes.OnHour, _backendGetErrorDelegate);

            Assert.AreEqual("fromMemCache", result);

            _pollySyncCacheProvider.Verify(x => x.TryGet(It.IsAny<string>()), Times.Once);

            _pollydistributedCacheProvider.Verify(x => x.TryGetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Never);

            await Task.Delay(_waitForBackgroundThreadToCompleteMs); // wait for background thread

            Assert.AreEqual(1, _numberOfTimesDataGetterDelegate1Called);

            DateTimeOffset whenDataWillNotBeFresh = new DateTimeOffset(2020, 05, 17, 21, 00, 00, 00, new TimeSpan(0, 0, 0));

            _pollySyncCacheProvider.Verify(x => x.Put(It.IsAny<string>(), It.Is<CachedItemWrapper<string>>(y => y.Content == "dataFromBackendGet" && y.ExpiresAt == whenDataWillNotBeFresh), It.Is<Ttl>(y=>y.Timespan == _defaultCacheDuration)), Times.Once);

           _pollydistributedCacheProvider.Verify(x => x.PutAsync(It.IsAny<string>(), It.Is<CachedItemWrapper<string>>(y=>y.Content == "dataFromBackendGet" && y.ExpiresAt == whenDataWillNotBeFresh), It.Is<Ttl>(y => y.Timespan == _defaultCacheDuration), It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Once);
        }

        [Test]
        public async Task DataInMemoryCacheButNotFresh_WaitForFreshData()
        {
            CachedItemWrapper<string> memoryCacheItem = new CachedItemWrapper<string>("fromMemCache", new DateTimeOffset(2020, 05, 17, 19, 59, 59, 00, new TimeSpan(0, 0, 0)));

            _pollySyncCacheProvider.Setup(x => x.TryGet(It.IsAny<string>())).Returns((true, memoryCacheItem));

            _mockableDateTime.Setup(x => x.UtcNow).Returns(new DateTimeOffset(2020, 05, 17, 20, 00, 00, 00, new TimeSpan(0, 0, 0)));

            MemDistCache inMemDistCache = new MemDistCache(_pollySyncCacheProvider.Object, _pollydistributedCacheProvider.Object, _mockableDateTime.Object);

            string result = await inMemDistCache.GetCachedDataAsync(_dataGetterDelegate1, "key", CancellationToken.None, ResetTimes.OnHour, _backendGetErrorDelegate, true);

            Assert.AreEqual("dataFromBackendGet", result);

            _pollySyncCacheProvider.Verify(x => x.TryGet(It.IsAny<string>()), Times.Once);

            _pollydistributedCacheProvider.Verify(x => x.TryGetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Never);

            Assert.AreEqual(1, _numberOfTimesDataGetterDelegate1Called);

            DateTimeOffset whenDataWillNotBeFresh = new DateTimeOffset(2020, 05, 17, 21, 00, 00, 00, new TimeSpan(0, 0, 0));

            _pollySyncCacheProvider.Verify(x => x.Put(It.IsAny<string>(), It.Is<CachedItemWrapper<string>>(y => y.Content == "dataFromBackendGet" && y.ExpiresAt == whenDataWillNotBeFresh), It.Is<Ttl>(y => y.Timespan == _defaultCacheDuration)), Times.Once);

            _pollydistributedCacheProvider.Verify(x => x.PutAsync(It.IsAny<string>(), It.Is<CachedItemWrapper<string>>(y => y.Content == "dataFromBackendGet" && y.ExpiresAt == whenDataWillNotBeFresh), It.Is<Ttl>(y => y.Timespan == _defaultCacheDuration), It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Once);
        }

        [Test]
        public async Task DataInMemoryCacheButNotFresh_BackendGetErrors()
        {
            CachedItemWrapper<string> memoryCacheItem = new CachedItemWrapper<string>("fromMemCache", new DateTimeOffset(2020, 05, 17, 19, 59, 59, 00, new TimeSpan(0, 0, 0)));

            _pollySyncCacheProvider.Setup(x => x.TryGet(It.IsAny<string>())).Returns((true, memoryCacheItem));

            _mockableDateTime.Setup(x => x.UtcNow).Returns(new DateTimeOffset(2020, 05, 17, 20, 00, 00, 00, new TimeSpan(0, 0, 0)));

            Func<CancellationToken, Task<string>> _dataGetterDelegate1 = async (token) =>
            {
                _numberOfTimesDataGetterDelegate1Called++;
                throw new Exception("An error");
            };

            MemDistCache inMemDistCache = new MemDistCache(_pollySyncCacheProvider.Object, _pollydistributedCacheProvider.Object, _mockableDateTime.Object);

            string result = await inMemDistCache.GetCachedDataAsync(_dataGetterDelegate1, "key", CancellationToken.None, ResetTimes.OnHour, _backendGetErrorDelegate);

            Assert.AreEqual("fromMemCache", result);

            _pollySyncCacheProvider.Verify(x => x.TryGet(It.IsAny<string>()), Times.Once);

            _pollydistributedCacheProvider.Verify(x => x.TryGetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Never);

            await Task.Delay(_waitForBackgroundThreadToCompleteMs); // wait for background thread


            Assert.AreEqual(1, _backendGetErrorDelegateTimesCalled);

            Assert.AreEqual(1, _numberOfTimesDataGetterDelegate1Called);

            DateTimeOffset whenDataWillNotBeFresh = new DateTimeOffset(2020, 05, 17, 21, 00, 00, 00, new TimeSpan(0, 0, 0));

            _pollySyncCacheProvider.Verify(x => x.Put(It.IsAny<string>(), It.Is<CachedItemWrapper<string>>(y => y.Content == "dataFromBackendGet" && y.ExpiresAt == whenDataWillNotBeFresh), It.Is<Ttl>(y => y.Timespan == _defaultCacheDuration)), Times.Never);

            _pollydistributedCacheProvider.Verify(x => x.PutAsync(It.IsAny<string>(), It.Is<CachedItemWrapper<string>>(y => y.Content == "dataFromBackendGet" && y.ExpiresAt == whenDataWillNotBeFresh), It.Is<Ttl>(y => y.Timespan == _defaultCacheDuration), It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Never);
        }

        [Test]
        public async Task DataNotInMemoryCache_DataInDistCacheFresh()
        {
            CachedItemWrapper<string> distCacheItem = new CachedItemWrapper<string>("fromDistCache", new DateTimeOffset(2020, 05, 17, 20, 00, 00, 00, new TimeSpan(0, 0, 0)));

            _pollySyncCacheProvider.Setup(x => x.TryGet(It.IsAny<string>())).Returns((false, null));

            _pollydistributedCacheProvider.Setup(x => x.TryGetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>(), It.IsAny<bool>())).ReturnsAsync((true, distCacheItem));

            
            _mockableDateTime.Setup(x => x.UtcNow).Returns(new DateTimeOffset(2020, 05, 17, 20, 00, 00, 00, new TimeSpan(0, 0, 0)));

            MemDistCache inMemDistCache = new MemDistCache(_pollySyncCacheProvider.Object, _pollydistributedCacheProvider.Object, _mockableDateTime.Object);

            string result = await inMemDistCache.GetCachedDataAsync(_dataGetterDelegate1, "key", CancellationToken.None, ResetTimes.OnHour, _backendGetErrorDelegate);

            Assert.AreEqual("fromDistCache", result);
            Assert.AreEqual(0, _numberOfTimesDataGetterDelegate1Called);

            _pollySyncCacheProvider.Verify(x => x.TryGet(It.IsAny<string>()), Times.Once);

            _pollydistributedCacheProvider.Verify(x => x.TryGetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Once);

            await Task.Delay(_waitForBackgroundThreadToCompleteMs); // wait for background thread

            Assert.AreEqual(0, _numberOfTimesDataGetterDelegate1Called);
            
            _pollySyncCacheProvider.Verify(x => x.Put(It.IsAny<string>(), It.Is<CachedItemWrapper<string>>(y => y.Content == "fromDistCache" && y.ExpiresAt == distCacheItem.ExpiresAt), It.Is<Ttl>(y => y.Timespan == _defaultCacheDuration)), Times.Once);
            
            _pollydistributedCacheProvider.Verify(x => x.PutAsync(It.IsAny<string>(), It.IsAny<CachedItemWrapper<string>>(), It.Is<Ttl>(y => y.Timespan == _defaultCacheDuration), It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Never);
        }


        [Test]
        public async Task DataNotInMemoryCache_DataInDistCacheNotFresh()
        {
            CachedItemWrapper<string> distCacheItem = new CachedItemWrapper<string>("fromDistCache", new DateTimeOffset(2020, 05, 17, 19, 59, 59, 00, new TimeSpan(0, 0, 0)));

            _pollySyncCacheProvider.Setup(x => x.TryGet(It.IsAny<string>())).Returns((false, null));

            _pollydistributedCacheProvider.Setup(x => x.TryGetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>(), It.IsAny<bool>())).ReturnsAsync((true, distCacheItem));


            _mockableDateTime.Setup(x => x.UtcNow).Returns(new DateTimeOffset(2020, 05, 17, 20, 00, 00, 00, new TimeSpan(0, 0, 0)));

            MemDistCache inMemDistCache = new MemDistCache(_pollySyncCacheProvider.Object, _pollydistributedCacheProvider.Object, _mockableDateTime.Object);

            string result = await inMemDistCache.GetCachedDataAsync(_dataGetterDelegate1, "key", CancellationToken.None, ResetTimes.OnHour, _backendGetErrorDelegate);

            Assert.AreEqual("fromDistCache", result);

            _pollySyncCacheProvider.Verify(x => x.TryGet(It.IsAny<string>()), Times.Once);

            _pollydistributedCacheProvider.Verify(x => x.TryGetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Once);

            await Task.Delay(_waitForBackgroundThreadToCompleteMs); // wait for background thread

            Assert.AreEqual(1, _numberOfTimesDataGetterDelegate1Called);


            DateTimeOffset whenDataWillNotBeFresh = new DateTimeOffset(2020, 05, 17, 21, 00, 00, 00, new TimeSpan(0, 0, 0));

            _pollySyncCacheProvider.Verify(x => x.Put(It.IsAny<string>(), It.Is<CachedItemWrapper<string>>(y => y.Content == "dataFromBackendGet" && y.ExpiresAt == whenDataWillNotBeFresh), It.Is<Ttl>(y => y.Timespan == _defaultCacheDuration)), Times.Once);

            _pollydistributedCacheProvider.Verify(x => x.PutAsync(It.IsAny<string>(), It.Is<CachedItemWrapper<string>>(y => y.Content == "dataFromBackendGet" && y.ExpiresAt == whenDataWillNotBeFresh), It.Is<Ttl>(y => y.Timespan == _defaultCacheDuration), It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Once);
        }

        [Test]
        public async Task DataNotInMemoryCache_DataInDistCacheNotFresh_WaitForFreshData()
        {
            CachedItemWrapper<string> distCacheItem = new CachedItemWrapper<string>("fromDistCache", new DateTimeOffset(2020, 05, 17, 19, 59, 59, 00, new TimeSpan(0, 0, 0)));

            _pollySyncCacheProvider.Setup(x => x.TryGet(It.IsAny<string>())).Returns((false, null));

            _pollydistributedCacheProvider.Setup(x => x.TryGetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>(), It.IsAny<bool>())).ReturnsAsync((true, distCacheItem));


            _mockableDateTime.Setup(x => x.UtcNow).Returns(new DateTimeOffset(2020, 05, 17, 20, 00, 00, 00, new TimeSpan(0, 0, 0)));

            MemDistCache inMemDistCache = new MemDistCache(_pollySyncCacheProvider.Object, _pollydistributedCacheProvider.Object, _mockableDateTime.Object);

            string result = await inMemDistCache.GetCachedDataAsync(_dataGetterDelegate1, "key", CancellationToken.None, ResetTimes.OnHour, _backendGetErrorDelegate, true);

            Assert.AreEqual("dataFromBackendGet", result);

            _pollySyncCacheProvider.Verify(x => x.TryGet(It.IsAny<string>()), Times.Once);

            _pollydistributedCacheProvider.Verify(x => x.TryGetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Once);

            Assert.AreEqual(1, _numberOfTimesDataGetterDelegate1Called);


            DateTimeOffset whenDataWillNotBeFresh = new DateTimeOffset(2020, 05, 17, 21, 00, 00, 00, new TimeSpan(0, 0, 0));

            _pollySyncCacheProvider.Verify(x => x.Put(It.IsAny<string>(), It.Is<CachedItemWrapper<string>>(y => y.Content == "dataFromBackendGet" && y.ExpiresAt == whenDataWillNotBeFresh), It.Is<Ttl>(y => y.Timespan == _defaultCacheDuration)), Times.Once);

            _pollydistributedCacheProvider.Verify(x => x.PutAsync(It.IsAny<string>(), It.Is<CachedItemWrapper<string>>(y => y.Content == "dataFromBackendGet" && y.ExpiresAt == whenDataWillNotBeFresh), It.Is<Ttl>(y => y.Timespan == _defaultCacheDuration), It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Once);
        }

        [Test]
        public async Task DataNotInMemoryCache_DataNotInDistCache()
        {
            _pollySyncCacheProvider.Setup(x => x.TryGet(It.IsAny<string>())).Returns((false, null));

            _pollydistributedCacheProvider.Setup(x => x.TryGetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>(), It.IsAny<bool>())).ReturnsAsync((false, null));


            _mockableDateTime.Setup(x => x.UtcNow).Returns(new DateTimeOffset(2020, 05, 17, 20, 00, 00, 00, new TimeSpan(0, 0, 0)));

            MemDistCache inMemDistCache = new MemDistCache(_pollySyncCacheProvider.Object, _pollydistributedCacheProvider.Object, _mockableDateTime.Object);

            string result = await inMemDistCache.GetCachedDataAsync(_dataGetterDelegate1, "key", CancellationToken.None, ResetTimes.OnHour, _backendGetErrorDelegate);

            Assert.AreEqual("dataFromBackendGet", result);

            _pollySyncCacheProvider.Verify(x => x.TryGet(It.IsAny<string>()), Times.Once);

            _pollydistributedCacheProvider.Verify(x => x.TryGetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Once);

            await Task.Delay(_waitForBackgroundThreadToCompleteMs); // wait for background thread

            Assert.AreEqual(1, _numberOfTimesDataGetterDelegate1Called);


            DateTimeOffset whenDataWillNotBeFresh = new DateTimeOffset(2020, 05, 17, 21, 00, 00, 00, new TimeSpan(0, 0, 0));

            _pollySyncCacheProvider.Verify(x => x.Put(It.IsAny<string>(), It.Is<CachedItemWrapper<string>>(y => y.Content == "dataFromBackendGet" && y.ExpiresAt == whenDataWillNotBeFresh), It.Is<Ttl>(y => y.Timespan == _defaultCacheDuration)), Times.Once);

            _pollydistributedCacheProvider.Verify(x => x.PutAsync(It.IsAny<string>(), It.Is<CachedItemWrapper<string>>(y => y.Content == "dataFromBackendGet" && y.ExpiresAt == whenDataWillNotBeFresh), It.Is<Ttl>(y => y.Timespan == _defaultCacheDuration), It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Once);
        }

    }
}
