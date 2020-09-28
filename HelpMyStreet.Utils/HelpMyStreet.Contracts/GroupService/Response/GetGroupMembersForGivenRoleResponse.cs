using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetGroupMembersForGivenRoleResponse
    {
        public List<int> UserIDs { get; set; }
    }
}
