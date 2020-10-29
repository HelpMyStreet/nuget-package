using HelpMyStreet.Utils.Extensions;
using HelpMyStreet.Utils.Utils;
using Microsoft.Extensions.Internal;
using Moq;
using NUnit.Framework;
using System;

namespace HelpMyStreet.UnitTests
{
    public class DateTimeUtilsTests
    {
        private Mock<ISystemClock> _systemClockMock;
        private DateTimeUtils _classUnderTest;

        [SetUp]
        public void SetUp()
        {
            _systemClockMock = new Mock<ISystemClock>();
            _systemClockMock.Setup(x => x.UtcNow).Returns(new DateTimeOffset(2020, 8, 1, 10, 0, 0, TimeSpan.Zero));

            _classUnderTest = new DateTimeUtils(_systemClockMock.Object);
        }

        [Test]
        public void FriendlyFutureDate_XWeeksAgo()
        {
            int weeksAgo = 3;
            DateTime dateTimeDue = _systemClockMock.Object.UtcNow.DateTime.AddDays(-7 * weeksAgo);

            string result = _classUnderTest.FriendlyFutureDate(dateTimeDue);

            Assert.AreEqual($"{weeksAgo} weeks ago", result);
        }

        [Test]
        public void FriendlyFutureDate_XDaysAgo()
        {
            int daysAgo = 3;
            DateTime dateTimeDue = _systemClockMock.Object.UtcNow.DateTime.AddDays(-1 * daysAgo);

            string result = _classUnderTest.FriendlyFutureDate(dateTimeDue);

            Assert.AreEqual($"{daysAgo} days ago", result);
        }

        [Test]
        public void FriendlyFutureDate_Yesterday()
        {
            DateTime dateTimeDue = _systemClockMock.Object.UtcNow.DateTime.AddDays(-1);
            string result = _classUnderTest.FriendlyFutureDate(dateTimeDue);

            Assert.AreEqual("yesterday", result);
        }

        [Test]
        public void FriendlyFutureDate_Today()
        {
            DateTime dateTimeDue = _systemClockMock.Object.UtcNow.DateTime;
            string result = _classUnderTest.FriendlyFutureDate(dateTimeDue);

            Assert.AreEqual("today", result);
        }

        [Test]
        public void FriendlyFutureDate_Tomorrow()
        {
            DateTime dateTimeDue = _systemClockMock.Object.UtcNow.DateTime.AddDays(1);
            string result = _classUnderTest.FriendlyFutureDate(dateTimeDue);

            Assert.AreEqual("tomorrow", result);
        }

        [Test]
        public void FriendlyFutureDate_On()
        {
            DateTime dateTimeDue = _systemClockMock.Object.UtcNow.DateTime.AddDays(4);
            string result = _classUnderTest.FriendlyFutureDate(dateTimeDue);

            Assert.AreEqual($"on {dateTimeDue.DayOfWeek}", result);
        }

        [Test]
        public void FriendlyFutureDate_Next()
        {
            DateTime dateTimeDue = _systemClockMock.Object.UtcNow.DateTime.AddDays(10);
            string result = _classUnderTest.FriendlyFutureDate(dateTimeDue);

            Assert.AreEqual($"next {dateTimeDue.DayOfWeek}", result);
        }

        [Test]
        public void FriendlyFutureDate_InXWeeks()
        {
            int inWeeks = 5;
            DateTime dateTimeDue = _systemClockMock.Object.UtcNow.DateTime.AddDays(inWeeks * 7);
            string result = _classUnderTest.FriendlyFutureDate(dateTimeDue);

            Assert.AreEqual($"in {inWeeks} weeks", result);
        }




        [Test]
        public void FriendlyPastDate_XWeeksAgo()
        {
            int weeksAgo = 3;
            DateTime dateTimeDue = _systemClockMock.Object.UtcNow.DateTime.AddDays(-7 * weeksAgo);

            string result = _classUnderTest.FriendlyPastDate(dateTimeDue);

            Assert.AreEqual($"{weeksAgo} weeks ago", result);
        }

        [Test]
        public void FriendlyPastDate_Last()
        {
            int daysAgo = 10;
            DateTime dateTimeDue = _systemClockMock.Object.UtcNow.DateTime.AddDays(-1 * daysAgo);

            string result = _classUnderTest.FriendlyPastDate(dateTimeDue);

            Assert.AreEqual($"last {dateTimeDue.DayOfWeek}", result);
        }

        [Test]
        public void FriendlyPastDate_On()
        {
            int daysAgo = 3;
            DateTime dateTimeDue = _systemClockMock.Object.UtcNow.DateTime.AddDays(-1 * daysAgo);

            string result = _classUnderTest.FriendlyPastDate(dateTimeDue);

            Assert.AreEqual($"on {dateTimeDue.DayOfWeek}", result);
        }

        [Test]
        public void FriendlyPastDate_Yesterday()
        {
            DateTime dateTimeDue = _systemClockMock.Object.UtcNow.DateTime.AddDays(-1);
            string result = _classUnderTest.FriendlyPastDate(dateTimeDue);

            Assert.AreEqual("yesterday", result);
        }

        [Test]
        public void FriendlyPastDate_Today()
        {
            DateTime dateTimeDue = _systemClockMock.Object.UtcNow.DateTime;
            string result = _classUnderTest.FriendlyPastDate(dateTimeDue);

            Assert.AreEqual("today", result);
        }

        [Test]
        public void FriendlyPastDate_Future()
        {
            DateTime dateTimeDue = _systemClockMock.Object.UtcNow.DateTime.AddDays(12);
            string result = _classUnderTest.FriendlyPastDate(dateTimeDue);

            Assert.AreEqual($"on {dateTimeDue:dd/MM/yyyy}", result);
        }

        [Test]
        public void SuffixTest()
        {
            DateTime dateTime = new DateTime(2000, 01, 01);
            string result = DateTimeExtensions.ToString(dateTime, "dnn", true);

            Assert.AreEqual("1st", result);
        }

        [Test]
        public void SuffixTest_Capital()
        {
            DateTime dateTime = new DateTime(2000, 01, 22);
            string result = DateTimeExtensions.ToString(dateTime, "dNN", true);

            Assert.AreEqual("22ND", result);
        }

        [Test]
        public void SuffixTest_11th()
        {
            DateTime dateTime = new DateTime(2009, 12, 11);
            string result = DateTimeExtensions.ToString(dateTime, "ddnn MMMM yyyy", true);

            Assert.AreEqual("11th December 2009", result);
        }
    }
}
