﻿using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Models;
using System;
using System.Collections.Generic;

namespace HelpMyStreet.Contracts.GroupService.Response
{    
    public class GetGroupMemberDetailsResponse
    {
        public List<GroupRoles> GroupRoles { get; set; }
        public List<UserCredential> UserCredentials { get; set; }
        public List<UserRoleAudit> UserRoleAudits { get; set; }
    }
}

