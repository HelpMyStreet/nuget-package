using System;
using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Extensions;
using NUnit.Framework;

namespace HelpMyStreet.UnitTests
{
    class SupportActivityExtensionsTests
    {
        [Test]
        public void FriendlyNameForEmail_AllValuesCovered()
        {
            foreach (SupportActivities val in Enum.GetValues(typeof(SupportActivities)))
            {
                _ = val.FriendlyNameForEmail();
            }
        }

        [Test]
        public void FriendlyNameShort_AllValuesCovered()
        {
            foreach (SupportActivities val in Enum.GetValues(typeof(SupportActivities)))
            {
                _ = val.FriendlyNameShort();
            }
        }

        [Test]
        public void PerfectTense_Singular_AllValuesCovered()
        {
            foreach (SupportActivities val in Enum.GetValues(typeof(SupportActivities)))
            {
                string s = val.PerfectTense(1);
                Assert.AreEqual(true, s.Contains("1"));
            }
        }

        [Test]
        public void PerfectTense_Plural_AllValuesCovered()
        {
            foreach (SupportActivities val in Enum.GetValues(typeof(SupportActivities)))
            {
                string s = val.PerfectTense(2);
                Assert.AreEqual(true, s.Contains("2"));
            }
        }

        [Test]
        public void AllowRepeatRequests_AllValuesCovered()
        {
            foreach (SupportActivities val in Enum.GetValues(typeof(SupportActivities)))
            {
               _ = val.AllowRepeatRequests();
            }
        }
    }
}
