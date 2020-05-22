﻿using HelpMyStreet.Cache;
using NUnit.Framework;
using System;

namespace HelpMyStreet.UnitTests
{
    public class TimeLengthsTests
    {
        [Test]
        public void NextMinute1()
        {
            DateTimeOffset timeNow = new DateTimeOffset(2020, 05, 22, 20, 08, 30, new TimeSpan(0));

            DateTimeOffset expectedResult = new DateTimeOffset(2020, 05, 22, 20, 09, 00, new TimeSpan(0));
            
            DateTimeOffset result = TimeLengths.OnMinute(timeNow);

            Assert.AreEqual(expectedResult,result);
        }

        [Test]
        public void NextMinute2()
        {
            DateTimeOffset timeNow = new DateTimeOffset(2020, 05, 22, 23, 59, 30, new TimeSpan(0));

            DateTimeOffset expectedResult = new DateTimeOffset(2020, 05, 23, 00, 00, 00, new TimeSpan(0));

            DateTimeOffset result = TimeLengths.OnMinute(timeNow);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void NextHour1()
        {
            DateTimeOffset timeNow = new DateTimeOffset(2020, 05, 22, 20, 08, 30, new TimeSpan(0));

            DateTimeOffset expectedResult = new DateTimeOffset(2020, 05, 22, 21, 00, 00, new TimeSpan(0));

            DateTimeOffset result = TimeLengths.OnHour(timeNow);

            Assert.AreEqual(expectedResult, result);
        }


        [Test]
        public void NextHour2()
        {
            DateTimeOffset timeNow = new DateTimeOffset(2020, 05, 22, 20, 08, 30, new TimeSpan(0));
            
            DateTimeOffset expectedResult = new DateTimeOffset(2020, 05, 22, 21, 00, 00, new TimeSpan(0));

            DateTimeOffset result = TimeLengths.OnHour(timeNow);

            Assert.AreEqual(expectedResult, result);
        }
    }
}