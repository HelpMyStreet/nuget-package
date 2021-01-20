using System;
using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Extensions
{
    public static class PartOfDayExtensions
    {
        public static (int, int) GetStartTimeBetweenHours(this PartOfDay partOfDay)
        {
            return partOfDay switch
            {
                PartOfDay.Morning => (6, 11),
                PartOfDay.Afternoon => (12, 18),
                PartOfDay.Night => (18, 23),
                _ => throw new ArgumentException("Unexpected Part Of Day")
            };
        }

        public static bool CheckStartTimeWithin(this PartOfDay partOfDay, DateTime dateTime)
        {
            var hours = partOfDay.GetStartTimeBetweenHours();
            return hours.Item1 <= dateTime.Hour && hours.Item2 >= dateTime.Hour;
        }
        
    }
}
