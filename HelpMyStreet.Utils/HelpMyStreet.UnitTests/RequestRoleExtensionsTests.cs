using System;
using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Extensions;
using NUnit.Framework;

namespace HelpMyStreet.UnitTests
{
    class RequestRoleExtensionsTests
    {
        [Test]
        public void LimitOneFeedbackPerRequest_AllValuesCovered()
        {
            foreach (var val in Enum.GetValues(typeof(RequestRoles)))
            {
                _ = ((RequestRoles)val).LimitOneFeedbackPerRequest();
            }
        }
    }
}
