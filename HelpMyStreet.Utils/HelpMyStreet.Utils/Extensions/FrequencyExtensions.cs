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
    }
}
