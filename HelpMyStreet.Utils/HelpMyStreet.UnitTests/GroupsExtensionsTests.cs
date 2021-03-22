using System;
using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Extensions;
using NUnit.Framework;

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

    }
}
