using System;
using System.Collections.Generic;
using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Extensions
{
    public static class GroupTypesExtensions
    {
        public static string GetString(this GroupTypes groupTypes)
        {
            return groupTypes switch
            {
                GroupTypes.HelpMyStreet => "Help My Street",
                GroupTypes.Local => "Local Group",
                GroupTypes.Regional => "Regional Group",
                GroupTypes.National => "National Group",
                _ => throw new ArgumentException(message: $"Unexpected GroupTypes: {groupTypes}", paramName: nameof(groupTypes))
            };
        }
    }
}
