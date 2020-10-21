using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelpMyStreet.Utils.Extensions
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string inputString)
        {
            return string.Join(" ", inputString.Split(' ').Where(word => word.Length > 0).Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
        }
    }
}
