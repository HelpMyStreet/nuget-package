using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Extensions;
using NUnit.Framework;

namespace HelpMyStreet.UnitTests
{
    class JobStatusExtensionsTests
    {
        [Test]
        public void FriendlyName_InProgress()
        {
            Assert.AreEqual("In Progress", JobStatuses.InProgress.FriendlyName());
        }

        [Test]
        public void FriendlyName_Done()
        {
            Assert.AreEqual("Done", JobStatuses.Done.FriendlyName());
        }
    }
}
