using System;

namespace HelpMyStreet.Cache
{
    public static class TimeLengths
    {
        public static Func<DateTimeOffset, DateTimeOffset> OnMinute => (timeNow) => GetLengthOfTimeUntilNextMinute(timeNow);
        public static Func<DateTimeOffset, DateTimeOffset> OnHour => (timeNow) => GetLengthOfTimeUntilNextHour(timeNow);
        public static Func<DateTimeOffset, DateTimeOffset> OnMidday => (timeNow) => GetLengthOfTimeUntilNextMidday(timeNow);

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

        private static DateTimeOffset GetLengthOfTimeUntilNextMidday(DateTimeOffset timeNow)
        {
            if (timeNow.Hour >= 12)
            {
                return new DateTimeOffset(timeNow.Year, timeNow.Month, timeNow.Day + 1, 12, 0, 0, timeNow.Offset);
            }
            else
            {
                return new DateTimeOffset(timeNow.Year, timeNow.Month, timeNow.Day, 12, 0, 0, timeNow.Offset);
            }
        }
        
    }
}
