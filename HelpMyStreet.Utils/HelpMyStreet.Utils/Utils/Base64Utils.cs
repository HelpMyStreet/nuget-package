using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;

namespace HelpMyStreet.Utils.Utils
{
    public static class Base64Utils
    {
        public static string Base64Encode(int plainText)
        {
            return Base64Encode(plainText.ToString());
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return WebEncoders.Base64UrlEncode(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = WebEncoders.Base64UrlDecode(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static int Base64DecodeToInt(string base64EncodedData)
        {
            var plainText = Base64Decode(base64EncodedData);
            return int.Parse(plainText);
        }

        public static int? TryBase64DecodeToInt(string base64EncodedData)
        {
            try
            {
                if (!string.IsNullOrEmpty(base64EncodedData))
                {
                    return Base64DecodeToInt(base64EncodedData);
                }
            }
            catch { }
            return null;
        }
    }
}
