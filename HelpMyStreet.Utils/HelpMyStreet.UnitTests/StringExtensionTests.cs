using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HelpMyStreet.Utils.Extensions;

namespace HelpMyStreet.UnitTests
{
    class StringExtensionTests
    {
        [Test]
        public void ToTitleCase_EmptyString()
        {
            Assert.AreEqual("", "".ToTitleCase());
        }

        [Test]
        public void ToTitleCase_Sentence()
        {
            Assert.AreEqual("The Quick Brown Fox Jumped Over The Lazy Dog", "the QUICK bROWN fOx jumped over THE LAZY Dog".ToTitleCase());
        }
    }
}
