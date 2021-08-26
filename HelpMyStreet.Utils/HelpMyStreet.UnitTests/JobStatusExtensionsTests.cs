using System;
using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Extensions;
using NUnit.Framework;

namespace HelpMyStreet.UnitTests
{
    class JobStatusExtensionsTests
    {
        [Test]
        public void FriendlyName_New()
        {
            Assert.AreEqual("Pending Approval", JobStatuses.New.FriendlyName());
        }

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

        [Test]
        public void Complete_Done()
        {
            Assert.AreEqual(true, JobStatuses.Done.Complete());
        }

        [Test]
        public void Complete_InProgress()
        {
            Assert.AreEqual(false, JobStatuses.InProgress.Complete());
        }

        [Test]
        public void Incomplete_Cancelled()
        {
            Assert.AreEqual(false, JobStatuses.Cancelled.Incomplete());
        }

        [Test]
        public void Incomplete_Open()
        {
            Assert.AreEqual(true, JobStatuses.Open.Incomplete());
        }

        [Test]
        public void Incomplete_AllValuesCovered()
        {
            foreach (JobStatuses val in Enum.GetValues(typeof(JobStatuses)))
            {
                _ = val.Incomplete();
            }
        }

        [Test]
        public void Complete_AllValuesCovered()
        {
            foreach (JobStatuses val in Enum.GetValues(typeof(JobStatuses)))
            {
                _ = val.Complete();
            }
        }
    }
}
