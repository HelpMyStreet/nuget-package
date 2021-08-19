using System;
using System.Collections.Generic;
using System.Text;
using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Extensions;
using NUnit.Framework;

namespace HelpMyStreet.UnitTests
{
    class PartOfDayExtensionsTests
    {
        [TestCase(PartOfDay.Night, 3, 30)]
        [TestCase(PartOfDay.Morning, 4, 30)]
        [TestCase(PartOfDay.Morning, 6, 0)]
        [TestCase(PartOfDay.Morning, 10, 0)]
        [TestCase(PartOfDay.Morning, 11, 30)]
        [TestCase(PartOfDay.Afternoon, 12, 0)]
        [TestCase(PartOfDay.Afternoon, 13, 30)]
        [TestCase(PartOfDay.Night, 18, 0)]
        [TestCase(PartOfDay.Night, 20, 0)]
        public void CheckStartTimeWithin_SpecficExamples(PartOfDay partOfDay, int hour, int minute)
        {
            DateTime dateTime = new DateTime(2020, 10, 01, hour, minute, 0);

            bool result = PartOfDayExtensions.CheckStartTimeWithin(partOfDay, dateTime);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void CheckStartTimeWithin_AllValuesCovered()
        {
            DateTime startDate = new DateTime(2021, 02, 02, 0, 0, 0);

            while (startDate < new DateTime(2021, 02, 5, 0, 0, 0))
            {
                startDate = startDate.AddMinutes(15);

                int matchedParts = 0;

                if (PartOfDayExtensions.CheckStartTimeWithin(PartOfDay.Morning, startDate)) { matchedParts++; }
                if (PartOfDayExtensions.CheckStartTimeWithin(PartOfDay.Afternoon, startDate)) { matchedParts++; }
                if (PartOfDayExtensions.CheckStartTimeWithin(PartOfDay.Night, startDate)) { matchedParts++; }

                Assert.AreEqual(1, matchedParts, $"Mismatch for time {startDate}");
            }
        }
    }
}