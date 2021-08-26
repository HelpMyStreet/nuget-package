using HelpMyStreet.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetGroupsWithMapDetailsResponse
    {
        public List<Group> Groups { get; set; }
    }
}
