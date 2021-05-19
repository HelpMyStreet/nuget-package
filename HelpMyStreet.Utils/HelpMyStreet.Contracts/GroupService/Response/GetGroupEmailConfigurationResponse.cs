using HelpMyStreet.Utils.Models;
using System.Collections.Generic;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetGroupEmailConfigurationResponse
    {
        public List<KeyValuePair<string,string>> EmailConfigurations { get; set; }
    }
}