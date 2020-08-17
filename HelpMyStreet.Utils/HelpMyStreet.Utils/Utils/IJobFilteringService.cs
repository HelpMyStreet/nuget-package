using HelpMyStreet.Utils.Dtos;
using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HelpMyStreet.Utils.Utils
{
    public interface IJobFilteringService
    {
        Task<List<JobSummary>> FilterJobSummaries(
            List<JobSummary> jobs,
            List<SupportActivities> supportActivities,
            string volunteerPostcode,
            double? distanceInMiles,
            Dictionary<SupportActivities, double?> activitySpecificSupportDistancesInMiles,
            int? referringGroupID,
            List<int> groups,
            List<JobStatuses> statuses,
            Dictionary<string, ILatitudeLongitude> postcodeDetails,
            CancellationToken cancellationToken);
    }
}
