using HelpMyStreet.Utils.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.UnitTests
{
    class Base64UtilsTests
    {
        [Test]
        public void Base64Encode_Base64Decode_EmptyString()
        {
            string result = Base64Utils.Base64Decode(Base64Utils.Base64Encode(""));

            Assert.AreEqual("", result);
        }

        [Test]
        public void Base64Encode_Base64Decode_HelloWorld()
        {
            string result = Base64Utils.Base64Decode(Base64Utils.Base64Encode("Hello World!"));

            Assert.AreEqual("Hello World!", result);
        }

        [Test]
        public void Base64Encode_Base64DecodeToInt()
        {
            int result = Base64Utils.Base64DecodeToInt(Base64Utils.Base64Encode(123));

            Assert.AreEqual(123, result);
        }

        [Test]
        public void Base64Encode_Base64DecodeToInt_Zero()
        {
            int result = Base64Utils.Base64DecodeToInt(Base64Utils.Base64Encode(0));

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Base64Encode_Base64DecodeToInt_Negative()
        {
            int result = Base64Utils.Base64DecodeToInt(Base64Utils.Base64Encode(-1));

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Base64Encode_Base64DecodeToInt_Invalid()
        {
            string encodedString = Base64Utils.Base64Encode("Not a number");

            Assert.Throws<FormatException>(() => { Base64Utils.Base64DecodeToInt(encodedString); });
        }
    }
}
