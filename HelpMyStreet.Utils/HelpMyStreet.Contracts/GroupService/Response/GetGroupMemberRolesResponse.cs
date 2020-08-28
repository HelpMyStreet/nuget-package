using System.Collections.Generic;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetGroupMemberRolesResponse
    {
        public Dictionary<int, List<int>> GroupMemberRoles { get; set; }
    }
}
