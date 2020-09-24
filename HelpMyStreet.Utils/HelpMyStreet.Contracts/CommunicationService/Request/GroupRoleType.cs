using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.CommunicationService.Request
{
    public class GroupRoleType
    {
        public int GroupId { get; set; }
        public GroupRoles GroupRoles { get; set; }
    }
}
