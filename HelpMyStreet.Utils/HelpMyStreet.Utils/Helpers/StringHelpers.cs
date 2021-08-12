using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace HelpMyStreet.Utils.Helpers
{
    public static class StringHelpers
    {
        private static readonly Regex LineBreakRegex = new Regex(@"(\n|\r){1,2}");

        public static string ToHtmlSafeStringWithLineBreaks(this string inputString)
        {
            return LineBreakRegex.Replace(HttpUtility.HtmlEncode(inputString), "<br />");
        }
    }
}
