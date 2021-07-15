using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Extensions
{
    public static class IntegerExtensions
    {
        public static string ToOccurrenceSuffix(this int integer, bool addHtmlTags = false)
        {
            string suffix = (integer % 100, integer % 10) switch
            {
                (11, _) => "th",
                (12, _) => "th",
                (13, _) => "th",
                (_, 1) => "st",
                (_, 2) => "nd",
                (_, 3) => "rd",
                (_, _) => "th",
            };

            return addHtmlTags switch
            {
                true => $"<sup>{suffix}</sup>",
                false => suffix,
            };
        }

        public static string ToAMPM(this int integer)
        {
            if (integer >= 0 && integer < 12)
                return "am";
            else
                return "pm";
        }
    }
}
