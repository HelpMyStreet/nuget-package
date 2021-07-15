using HelpMyStreet.Utils.Enums;
using System.Collections.Generic;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetUserLocationsResponse
    {
        public List<Location> Locations { get; set; }
    }
}
