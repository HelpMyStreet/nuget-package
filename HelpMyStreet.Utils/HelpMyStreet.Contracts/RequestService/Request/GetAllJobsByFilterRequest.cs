using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using HelpMyStreet.Contracts.RequestService.Response;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class GetAllJobsByFilterRequest : IRequest<GetAllJobsByFilterResponse>
    {
        /// <summary>
        /// Filter by userID if passed in
        /// </summary>
        public int? AllocatedToUserId { get; set; }

        //If supplied, **exclude** any jobs which have the same
        // RequestID and SupportActivityID as a Job allocated to
        // the supplied UserID.
        public int? ExcludeSiblingsOfJobsAllocatedToUserID;

        /// <summary>
        /// Support activities to be returned
        /// Supply null to return all activities
        /// </summary>
        public SupportActivityRequest SupportActivities { get; set; }

        /// <summary>
        /// Base postcode for calculating distances
        /// Required
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Default support distance
        /// Supply null to return requests nationwide
        /// </summary>
        public double? DistanceInMiles { get; set; }

        /// <summary>
        /// Overrides DistanceInMiles for specific activities
        /// Supply null for an activity type to return requets nationwide
        /// </summary>
        public Dictionary<SupportActivities,double?> ActivitySpecificSupportDistancesInMiles { get; set; }

        // If supplied, filters to this referring group
        public int? ReferringGroupID { get; set; }
        public bool IncludeChildGroups { get; set; }

        public GroupRequest Groups { get; set; }
        public JobStatusRequest JobStatuses {get; set; }

        // If supplied, returns jobs **ending** after the specified datetime
        public DateTime? DateFrom { get; set; }

        // If supplied, returns jobs **starting** before the specified datetime
        public DateTime? DateTo { get; set; }

        public RequestTypeRequest RequestType { get; set; }
    }
}
