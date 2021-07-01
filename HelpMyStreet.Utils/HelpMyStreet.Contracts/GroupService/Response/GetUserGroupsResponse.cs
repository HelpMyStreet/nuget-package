using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetUserGroupsResponse
    {
        public List<int> Groups { get; set; }
        public int MaxOpenShiftRadius { get; set; }
        public int MaxOpenRequestsRadius { get; set; }
    }
}
