﻿using HelpMyStreet.Utils.Utils;
using HelpMyStreet.Utils.Enums;
using System;

namespace HelpMyStreet.Utils.Extensions
{
    public static class DateTimeExtensions
    {
        public static string FriendlyFutureDate(this DateTime dateTimeDue)
        {
            return new DateTimeUtils(new MockableDateTime()).FriendlyFutureDate(dateTimeDue.ToUKFromUTCTime());
        }

        public static string FriendlyPastDate(this DateTime dateTimeDue)
        {
            return new DateTimeUtils(new MockableDateTime()).FriendlyPastDate(dateTimeDue.ToUKFromUTCTime());
        }

        public static string JobDueDate(this DateTime dateTimeDue, DueDateType dueDateType)
        {
            return new DateTimeUtils(new MockableDateTime()).JobDueDate(dateTimeDue.ToUKFromUTCTime(), dueDateType);
        }

        public static DateTime ToUKFromUTCTime(this DateTime dateTime)
        {
            try
            {
                var tz = TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Utc, TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"));
                return tz;
               }
            catch
            {
                var tz = TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Utc, TimeZoneInfo.FindSystemTimeZoneById("GMT")); // macOS
                return tz;
            }   
            
        }

        public static DateTime ToUTCFromUKTime(this DateTime dateTime)
        {
            try
            {
                var tz = TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"), TimeZoneInfo.Utc);
                return tz;
            }
            catch
            {
                var tz = TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.FindSystemTimeZoneById("GMT"), TimeZoneInfo.Utc); // macOS
                return tz;
            }
        }

        public static string FormatDate(this DateTime dateTime, DateTimeFormat dateTimeFormat, bool convertFromUTC = true)
        {
            if (convertFromUTC)
            {
                dateTime = dateTime.ToUKFromUTCTime();
            }

            string shortDateFormat = "dd/MM/yy";
            string longDateFormat = "dddd, dnn MMMM";
            string timeformat = "h:mm xx";

            switch (dateTimeFormat)
            {
                case DateTimeFormat.LongDateFormat:
                    return dateTime.ToString(longDateFormat).Replace("nn", dateTime.Day.ToOccurrenceSuffix().ToLower());
                case DateTimeFormat.LongDateHTMLFormat:
                    return dateTime.ToString(longDateFormat).Replace("nn", dateTime.Day.ToOccurrenceSuffix(true).ToLower());
                case DateTimeFormat.ShortDateFormat:
                    return dateTime.ToString(shortDateFormat);                    
                case DateTimeFormat.TimeFormat:
                    return $"{dateTime.ToString(timeformat).Replace("xx", dateTime.Hour.ToAMPM())}";
                case DateTimeFormat.LongDateTimeFormat:
                    return $"{dateTime.ToString(longDateFormat).Replace("nn", dateTime.Day.ToOccurrenceSuffix().ToLower())} {dateTime.ToString(timeformat).Replace("xx", dateTime.Hour.ToAMPM())}";
                case DateTimeFormat.LongDateTimeHTMLFormat:
                    return $"{dateTime.ToString(longDateFormat).Replace("nn", dateTime.Day.ToOccurrenceSuffix(true).ToLower())} {dateTime.ToString(timeformat).Replace("xx", dateTime.Hour.ToAMPM())}";
                case DateTimeFormat.ShortDateTimeFormat:
                    return $"{dateTime.ToString(shortDateFormat).Replace("nn", dateTime.Day.ToOccurrenceSuffix().ToLower())} {dateTime.ToString(timeformat).Replace("xx", dateTime.Hour.ToAMPM())}";
                default:
                    throw new Exception($"Unknown format {dateTimeFormat.ToString()}");
            }
        }
    }
}
