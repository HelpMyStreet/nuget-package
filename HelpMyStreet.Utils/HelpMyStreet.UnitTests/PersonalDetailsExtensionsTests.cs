using System;
using System.Collections.Generic;
using System.Text;
using HelpMyStreet.Utils.Extensions;
using NUnit.Framework;

namespace HelpMyStreet.UnitTests
{
    class PersonalDetailsExtensionsTests
    {
        [Test]
        public void LocationSummary_NoInput()
        {
            Assert.AreEqual("", PersonalDetailsExtensions.LocationSummary(null, null));
        }

        [Test]
        public void LocationSummary_LocalityAndPostcode()
        {
            Assert.AreEqual("Nottingham (NG5)", PersonalDetailsExtensions.LocationSummary("NOTTINGHAM", "NG5 1AA"));
        }

        [Test]
        public void LocationSummary_NullLocality()
        {
            Assert.AreEqual("(NG5)", PersonalDetailsExtensions.LocationSummary(null, "ng5 1AA"));
        }

        [Test]
        public void LocationSummary_EmptyPostcode()
        {
            Assert.AreEqual("Nottingham", PersonalDetailsExtensions.LocationSummary("NOTTINGHAM", ""));
        }
    }
}
