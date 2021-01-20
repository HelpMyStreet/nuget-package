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
        
    }
}
