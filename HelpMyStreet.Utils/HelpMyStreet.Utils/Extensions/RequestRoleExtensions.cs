﻿using System;
using System.Collections.Generic;
using System.Text;
using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Extensions
{
    public static class RequestRoleExtensions
    {
        public static bool LimitOneFeedbackPerRequest(this RequestRoles role)
        {
            return role switch
            {
                RequestRoles.Recipient => true,
                RequestRoles.Requestor => true,
                RequestRoles.Volunteer => false,
                RequestRoles.GroupAdmin => false,
                _ => throw new ArgumentException($"Unexpected RequestRoles value: {role}", nameof(role))
            };
        }
    }
}
