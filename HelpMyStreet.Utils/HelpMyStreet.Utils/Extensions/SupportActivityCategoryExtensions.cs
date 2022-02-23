using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Extensions
{
    public static class SupportActivityCategoryExtensions
    {
        public static string FriendlyName(this SupportActivityCategory category)
        {
            return category switch
            {
                SupportActivityCategory.EverydayActivities => "Everyday activities",
                SupportActivityCategory.Befriending => "Befriending",
                SupportActivityCategory.CommunityVolunteering => "Community volunteering",
                SupportActivityCategory.AnythingElse => "Anything else",
                _ => throw new ArgumentException(message: $"Unexpected SupportActivityCategory: {category}", paramName: nameof(category))
            };
        }
    }
}
