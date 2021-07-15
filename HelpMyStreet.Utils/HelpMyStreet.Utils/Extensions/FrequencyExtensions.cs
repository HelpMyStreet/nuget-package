using System;
using System.Collections.Generic;
using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Extensions
{
    public static class FrequencyExtensions
    {
        public static int FrequencyDays(this Frequency frequency)
        {
            return frequency switch
            {
                Frequency.Daily => 1,
                Frequency.Weekly => 7,
                Frequency.Fortnightly => 14,
                Frequency.EveryFourWeeks => 28,
                _ => throw new ArgumentException(message: $"Unexpected Frequency: {frequency}", paramName: nameof(frequency))
            };
        }

        public static int MaxOccurrences(this Frequency frequency)
        {
            return frequency switch
            {
                Frequency.Once => 1,
                Frequency.Daily => 14,
                Frequency.Weekly => 12,
                Frequency.Fortnightly => 6,
                Frequency.EveryFourWeeks => 3,
                _ => throw new ArgumentException($"Unexpected Frequency {frequency}", nameof(frequency))
            };
        }

        public static string FriendlyName(this Frequency frequency)
        {
            return frequency switch
            {
                Frequency.Once => "Just once",
                Frequency.EveryFourWeeks => "Every 4 weeks",
                _ => frequency.ToString()
            };
        }
    }
}
