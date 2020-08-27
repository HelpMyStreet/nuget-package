using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetGroupMemberRolesResponse
    {
        public Dictionary<int, List<int>> GroupMemberRoles { get; set; }
    }
}
