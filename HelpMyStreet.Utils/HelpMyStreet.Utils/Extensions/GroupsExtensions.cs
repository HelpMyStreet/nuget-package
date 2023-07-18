using System;
using System.Collections.Generic;
using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Extensions
{
    public static class GroupsExtensions
    {
        public static string GroupIdentifier(this Groups groups)
        {
            return groups switch
            {
                Groups.Generic => "HMS",                
                Groups.Ruddington => "RUD",
                Groups.AgeUKWirral => "WIR",                
                Groups.Sandbox => "TEST",                
                Groups.Southwell => "SW",
                _ => throw new ArgumentException(message: $"Unexpected Group: {groups}", paramName: nameof(groups))
            };
        }

        public static bool IsEnabled(this Groups groups)
        {
            return groups switch
            {
                _ => true
            };
        }
    }
}
