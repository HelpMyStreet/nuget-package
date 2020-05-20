using System;

namespace HelpMyStreet.Utils.MemDistCache
{
    public class ResetTimes
    {
        public static Func<DateTimeOffset, DateTimeOffset> OnMinute => (timeNow) => GetLengthOfTimeUntilNextMinute(timeNow);
        public static Func<DateTimeOffset, DateTimeOffset> OnHour => (timeNow) => GetLengthOfTimeUntilNextHour(timeNow);

        private static DateTimeOffset GetLengthOfTimeUntilNextHour(DateTimeOffset timeNow)
        {
            DateTimeOffset nowPlusOneMinute = timeNow.AddHours(1);
            DateTimeOffset theNextMinuteWithoutSeconds = new DateTime(nowPlusOneMinute.Year, nowPlusOneMinute.Month, nowPlusOneMinute.Day, nowPlusOneMinute.Hour, 0, 0, DateTimeKind.Utc);
            return theNextMinuteWithoutSeconds;
        }

        private static DateTimeOffset GetLengthOfTimeUntilNextMinute(DateTimeOffset timeNow)
        {
            DateTimeOffset nowPlusOneMinute = timeNow.AddMinutes(1);
            DateTimeOffset theNextMinuteWithoutSeconds = new DateTime(nowPlusOneMinute.Year, nowPlusOneMinute.Month, nowPlusOneMinute.Day, nowPlusOneMinute.Hour, nowPlusOneMinute.Minute, 0, DateTimeKind.Utc);
            return theNextMinuteWithoutSeconds;
        }

    }
}
