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

            Assert.AreEqual($"on {dateTimeDue:dd/MM/yy}", result);
        }

        [Test]
        public void ToUKFromUTCTime_Summer()
        {
            DateTime dateTime = new DateTime(2000, 8, 1, 10, 0, 0);
            DateTime result = dateTime.ToUKFromUTCTime();
            Assert.AreEqual(dateTime.AddHours(1), result);
        }

        [Test]
        public void ToUKFromUTCTime_Winter()
        {
            DateTime dateTime = new DateTime(2000, 1, 1, 10, 0, 0);
            DateTime result = dateTime.ToUKFromUTCTime();
            Assert.AreEqual(dateTime, result);
        }

        [Test]
        public void ToUTCFromUKTime_Summer()
        {
            DateTime dateTime = new DateTime(2000, 8, 1, 10, 0, 0);
            DateTime result = dateTime.ToUTCFromUKTime();
            Assert.AreEqual(dateTime.AddHours(-1), result);
        }

        [Test]
        public void ToUTCFromUKTime_Winter()
        {
            DateTime dateTime = new DateTime(2000, 1, 1, 10, 0, 0);
            DateTime result = dateTime.ToUTCFromUKTime();
            Assert.AreEqual(dateTime, result);
        }


        [Test]
        public void ToLongDate()
        {
            DateTime dateTime = new DateTime(2021, 1, 1, 10, 0, 0);
            string result = dateTime.FormatDate(Utils.Enums.DateTimeFormat.LongDateFormat);
            Assert.AreEqual("Friday, 1st January", result);
        }

        [Test]
        public void ToLongDateMarkdown()
        {
            DateTime dateTime = new DateTime(2021, 1, 1, 10, 0, 0);
            string result = dateTime.FormatDate(Utils.Enums.DateTimeFormat.LongDateHTMLFormat);
            Assert.AreEqual("Friday, 1<sup>st</sup> January", result);
        }

        [Test]
        public void ToLongDateMarkdownWithYear()
        {
            DateTime dateTime = new DateTime(2021, 1, 1, 10, 0, 0);
            string result = dateTime.FormatDate(Utils.Enums.DateTimeFormat.LongDateTimeHTMLFormatWithYear);
            Assert.AreEqual("Friday, 1<sup>st</sup> January 2021", result);
        }

        [Test]
        public void ToShortDate()
        {
            DateTime dateTime = new DateTime(2021, 1, 1, 10, 0, 0);
            string result = dateTime.FormatDate(Utils.Enums.DateTimeFormat.ShortDateFormat);
            Assert.AreEqual("01/01/21", result);
        }

        [Test]
        public void ToAMTime()
        {
            DateTime dateTime = new DateTime(2000, 1, 10, 11, 30, 0);
            string result = dateTime.FormatDate(Utils.Enums.DateTimeFormat.TimeFormat);
            Assert.AreEqual("11:30 am", result);
        }

        [Test]
        public void ToPMTime()
        {
            DateTime dateTime = new DateTime(2000, 1, 10, 14, 30, 0);
            string result = dateTime.FormatDate(Utils.Enums.DateTimeFormat.TimeFormat);
            Assert.AreEqual("2:30 pm", result);
        }

        [Test]
        public void ToLongDateTime()
        {
            DateTime dateTime = new DateTime(2021, 1, 1, 10, 0, 0);
            string result = dateTime.FormatDate(Utils.Enums.DateTimeFormat.LongDateTimeFormat);
            Assert.AreEqual("Friday, 1st January 10:00 am", result);
        }

        [Test]
        public void ToLongDateTimeMarkdown()
        {
            DateTime dateTime = new DateTime(2021, 1, 2, 10, 0, 0);
            string result = dateTime.FormatDate(Utils.Enums.DateTimeFormat.LongDateTimeHTMLFormat);
            Assert.AreEqual("Saturday, 2<sup>nd</sup> January 10:00 am", result);
        }

        [Test]
        public void ToShortDateTime()
        {
            DateTime dateTime = new DateTime(2021, 1, 1, 10, 0, 0);
            string result = dateTime.FormatDate(Utils.Enums.DateTimeFormat.ShortDateTimeFormat);
            Assert.AreEqual("01/01/21 10:00 am", result);
        }

        [Test]
        public void WhenOpenUntilPassedIn_Then_MessageShouldContainOpenUntil()
        {
            DateTime dateTime = new DateTime(2023, 1, 1);

            string  result = _classUnderTest.JobDueDate(dateTime, Utils.Enums.DueDateType.OpenUntil);

            Assert.AreEqual($"Open until 01/01/23", result);
        }
    }
}
