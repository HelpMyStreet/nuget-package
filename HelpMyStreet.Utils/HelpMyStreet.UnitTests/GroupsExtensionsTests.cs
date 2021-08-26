using System;
using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Extensions;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace HelpMyStreet.UnitTests
{
    class GroupsExtensionsTests
    {
        [Test]
        public void GroupReference_AllValuesCovered()
        {
            foreach (Groups val in Enum.GetValues(typeof(Groups)))
            {
                _ = val.GroupIdentifier();
            }
        }

        [Test]
        public void GroupReference_IsUnique()
        {
            var listOfIdentifiers = new List<string>();
            foreach (Groups val in Enum.GetValues(typeof(Groups)))
            {
                listOfIdentifiers.Add(val.GroupIdentifier());
            }
            Assert.AreEqual(listOfIdentifiers.Distinct().Count(), listOfIdentifiers.Count());
        }

    }
}
