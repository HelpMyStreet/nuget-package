using System;

namespace HelpMyStreet.Cache
{
    public static class TimeLengths
    {
        public static Func<DateTimeOffset, DateTimeOffset> OnMinute => (timeNow) => GetLengthOfTimeUntilNextMinute(timeNow);
        public static Func<DateTimeOffset, DateTimeOffset> OnHour => (timeNow) => GetLengthOfTimeUntilNextHour(timeNow);

        private static DateTimeOffset GetLengthOfTimeUntilNextHour(DateTimeOffset timeNow)
        {
            DateTimeOffset nowPlusOneHour = timeNow.AddHours(1);
            DateTimeOffset theNextMinuteWithoutSeconds = new DateTime(nowPlusOneHour.Year, nowPlusOneHour.Month, nowPlusOneHour.Day, nowPlusOneHour.Hour, 0, 0, DateTimeKind.Utc);
            return theNextMinuteWithoutSeconds;
        }

        private static DateTimeOffset GetLengthOfTimeUntilNextMinute(DateTimeOffset timeNow)
        {
            DateTimeOffset nowPlusOneMinute = timeNow.AddMinutes(1);
            DateTimeOffset theNextMinuteWithoutSeconds = new DateTime(nowPlusOneMinute.Year, nowPlusOneMinute.Month, nowPlusOneMinute.Day, nowPlusOneMinute.Hour, nowPlusOneMinute.Minute, 0, DateTimeKind.Utc);
            return theNextMinuteWithoutSeconds;
        }

        private static DateTimeOffset GetLengthOfTimeUntilNextDay(DateTimeOffset timeNow)
        {
            DateTimeOffset nowPlusOneDay = timeNow.AddDays(1);
            DateTimeOffset theNextMinuteWithoutSeconds = new DateTime(nowPlusOneDay.Year, nowPlusOneDay.Month, nowPlusOneDay.Day, nowPlusOneDay.Hour, nowPlusOneDay.Minute, 0, DateTimeKind.Utc);
            return theNextMinuteWithoutSeconds;
        }
    }
}
