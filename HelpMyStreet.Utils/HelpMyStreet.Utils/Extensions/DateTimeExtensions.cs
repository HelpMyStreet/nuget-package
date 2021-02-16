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

        public static string ShiftyDate(this DateTime dateTime)
        {
            return new DateTimeUtils(new MockableDateTime()).ShiftyDate(dateTime);
        }


        public static string ShiftyTime(this DateTime dateTime)
        {
            return new DateTimeUtils(new MockableDateTime()).ShiftyTime(dateTime);
        }

        public static string ToString(this DateTime dateTime, string format, bool useExtendedSpecifiers)
        {
            return useExtendedSpecifiers
                ? dateTime.ToString(format)
                    .Replace("nn", dateTime.Day.ToOccurrenceSuffix().ToLower())
                    .Replace("NN", dateTime.Day.ToOccurrenceSuffix().ToUpper())
                : dateTime.ToString(format);
        }

        public static DateTime ToUKFromUTCTime(this DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Utc, TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"));
        }

        public static DateTime ToUTCFromUKTime(this DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"), TimeZoneInfo.Utc);
        }

        public static string FormatDate(this DateTime dateTime, DateTimeFormat dateTimeFormat)
        {
            string shortDateFormat = "dd/MM/yy";
            string longDateFormat = "dddd, dnn MMMM";
            string timeformat = "h:mm xx";

            switch (dateTimeFormat)
            {
                case DateTimeFormat.LongDateFormat:
                    return dateTime.ToUKFromUTCTime().ToString(longDateFormat).Replace("nn", dateTime.Day.ToOccurrenceSuffix().ToLower());
                case DateTimeFormat.ShortDateFormat:
                    return dateTime.ToUKFromUTCTime().ToString(shortDateFormat);                    
                case DateTimeFormat.TimeFormat:
                    return $"{dateTime.ToUKFromUTCTime().ToString(timeformat).Replace("xx", dateTime.Hour.ToAMPM())}";
                case DateTimeFormat.LongDateTimeFormat:
                    return $"{dateTime.ToUKFromUTCTime().ToString(longDateFormat).Replace("nn", dateTime.Day.ToOccurrenceSuffix().ToLower())} {dateTime.ToUKFromUTCTime().ToString(timeformat).Replace("xx", dateTime.Hour.ToAMPM())}";
                case DateTimeFormat.ShortDateTimeFormat:
                    return $"{dateTime.ToUKFromUTCTime().ToString(shortDateFormat).Replace("nn", dateTime.Day.ToOccurrenceSuffix().ToLower())} {dateTime.ToUKFromUTCTime().ToString(timeformat).Replace("xx", dateTime.Hour.ToAMPM())}";
                default:
                    throw new Exception($"Unknown format {dateTimeFormat.ToString()}");
            }
        }
    }
}
