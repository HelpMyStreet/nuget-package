using HelpMyStreet.Contracts.RequestService.Response;
using HelpMyStreet.Utils.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class GetShiftRequestsByFilterRequest : IRequest<GetShiftRequestsByFilterResponse>
    {
        // If supplied, filters to that referring group
        public int? ReferringGroupID { get; set; }

        // If supplied, returns shifts available to those groups
        public GroupRequest Groups { get; set; }

        // If supplied, returns jobs at these locations
        public LocationsRequest Locations { get; set; }

        // If supplied, returns jobs **ending** after the specified datetime
        public DateTime? DateFrom { get; set; }

        // If supplied, returns jobs **starting** before the specified datetime
        public DateTime? DateTo { get; set; }
    }
}
