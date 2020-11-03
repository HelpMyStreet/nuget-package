using HelpMyStreet.Utils.Utils;
using HelpMyStreet.Utils.Enums;
using System;

namespace HelpMyStreet.Utils.Extensions
{
    public static class DateTimeExtensions
    {
        public static string FriendlyFutureDate(this DateTime dateTimeDue)
        {
            return new DateTimeUtils(new MockableDateTime()).FriendlyFutureDate(dateTimeDue);
        }

        public static string FriendlyPastDate(this DateTime dateTimeDue)
        {
            return new DateTimeUtils(new MockableDateTime()).FriendlyPastDate(dateTimeDue);
        }

        public static string JobDueDate(this DateTime dateTimeDue, DueDateType dueDateType)
        {
            return new DateTimeUtils(new MockableDateTime()).JobDueDate(dateTimeDue, dueDateType);
        }

        public static string ToString(this DateTime dateTime, string format, bool useExtendedSpecifiers)
        {
            return useExtendedSpecifiers
                ? dateTime.ToString(format)
                    .Replace("nn", dateTime.Day.ToOccurrenceSuffix().ToLower())
                    .Replace("NN", dateTime.Day.ToOccurrenceSuffix().ToUpper())
                : dateTime.ToString(format);
        }
    }
}
