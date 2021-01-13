using HelpMyStreet.Contracts.RequestService.Response;
using HelpMyStreet.Utils.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class GetOpenShiftJobsByFilterRequest : IRequest<GetOpenShiftJobsByFilterResponse>
    {
        //If supplied, **exclude** any jobs which have the same
        // RequestID and SupportActivityID as a Job allocated to
        // the supplied UserID.
        public int? ExcludeSiblingsOfJobsAllocatedToUserID;

        // If supplied, filters to those activities
        public SupportActivityRequest SupportActivities { get; set; }

        // If supplied, filters to this referring group
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
