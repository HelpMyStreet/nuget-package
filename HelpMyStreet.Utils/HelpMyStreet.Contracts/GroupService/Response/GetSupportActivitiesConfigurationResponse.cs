using HelpMyStreet.Utils.Models;
using System.Collections.Generic;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetSupportActivitiesConfigurationResponse
    {
        public List<SupportActivityConfiguration> SupportActivityConfigurations { get; set; }
    }
}