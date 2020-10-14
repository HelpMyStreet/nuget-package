﻿using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Extensions
{
    public static class GroupRolesExtensions
    {
        public static string FriendlyName(this GroupRoles role)
        {
            return role switch
            {
                GroupRoles.UserAdmin => "User Admin",
                GroupRoles.TaskAdmin => "Request Admin",
                GroupRoles.RequestSubmitter => "Request Submitter",
                _ => role.ToString()
            };
        }
    }
}
