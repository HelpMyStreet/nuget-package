using HelpMyStreet.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetGroupLocationsResponse
    {
        public List<LocationDetails> Locations { get; set; }
    }
}
