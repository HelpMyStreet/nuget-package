using System;
using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Extensions
{
    public static class PartOfDayExtensions
    {
        public static bool CheckStartTimeWithin(this PartOfDay partOfDay, DateTime dateTime)
        {
            return partOfDay switch
            {
                PartOfDay.Morning => dateTime.Hour >= 4 && dateTime.Hour < 12,
                PartOfDay.Afternoon => dateTime.Hour >= 12 && dateTime.Hour < 18,
                PartOfDay.Night => dateTime.Hour < 4 || dateTime.Hour >= 18,
                _ => throw new ArgumentException("Unexpected Part Of Day")
            };
        }
    }
}
