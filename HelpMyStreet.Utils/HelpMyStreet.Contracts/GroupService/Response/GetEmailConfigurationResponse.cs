using HelpMyStreet.Utils.Models;
using System.Collections.Generic;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetEmailConfigurationResponse
    {
        public List<KeyValuePair<string,string>> EmailConfigurations { get; set; }
    }
}