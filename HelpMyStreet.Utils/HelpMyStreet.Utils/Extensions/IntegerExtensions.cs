using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Extensions
{
    public static class IntegerExtensions
    {
        public static string ToOccurrenceSuffix(this int integer)
        {
            switch (integer % 100)
            {
                case 11:
                case 12:
                case 13:
                    return "th";
            }
            return (integer % 10) switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th",
            };
        }
    }
}
