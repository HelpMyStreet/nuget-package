using HelpMyStreet.Utils.Dtos;
using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserService.Core.Utils;

namespace HelpMyStreet.Utils.Utils
{
    public class JobFilteringService : IJobFilteringService
    {
        private readonly IDistanceCalculator _distanceCalculator;

        public JobFilteringService(IDistanceCalculator distanceCalculator)
        {
            _distanceCalculator = distanceCalculator;
        }

        public async Task<List<JobSummary>> FilterJobSummaries(
            List<JobSummary> jobs,
            List<SupportActivities> supportActivities,
            string volunteerPostcode,
            double? distanceInMiles,
            Dictionary<SupportActivities, double?> activitySpecificSupportDistancesInMiles,
            int? referringGroupID,
            List<int> groups,
            List<JobStatuses> statuses,
            Dictionary<string, ILatitudeLongitude> postcodeDetails,
            CancellationToken cancellationToken)
        {
            if(postcodeDetails == null)
            {
                return jobs;
            }

            jobs = await AttachedDistanceToJobSummaries(volunteerPostcode, postcodeDetails, jobs);

            if (jobs == null)
            {
                // For now, return no jobs to avoid breaking things downstream
                return new List<JobSummary>();
            }

            jobs = jobs.Where(w => supportActivities == null || supportActivities.Contains(w.SupportActivity))
                       .Where(w => w.DistanceInMiles <= GetSupportDistanceForActivity(w.SupportActivity, distanceInMiles, activitySpecificSupportDistancesInMiles))
                       .ToList();

            if (referringGroupID.HasValue)
            {
                jobs = jobs.Where(w => w.ReferringGroupID == referringGroupID.Value).ToList();
            }

            if (groups != null)
            {
                jobs = jobs.Where(t2 => groups.Any(t1 => t2.Groups.Contains(t1))).ToList();
            }

            if (statuses != null)
            {
                jobs = jobs.Where(t2 => statuses.Contains(t2.JobStatus)).ToList();
            }

            return jobs;
        }

        private double GetSupportDistanceForActivity(SupportActivities supportActivity, double? distanceInMiles, Dictionary<SupportActivities, double?> activitySpecificSupportDistancesInMiles)
        {
            if (activitySpecificSupportDistancesInMiles != null && activitySpecificSupportDistancesInMiles.ContainsKey(supportActivity))
            {
                return activitySpecificSupportDistancesInMiles[supportActivity] ?? int.MaxValue;
            }
            else
            {
                return distanceInMiles ?? int.MaxValue;
            }
        }

        private async Task<List<JobSummary>> AttachedDistanceToJobSummaries(string volunteerPostCode, Dictionary<string, ILatitudeLongitude> postcodeDetails, List<JobSummary> jobSummaries)
        {
            ILatitudeLongitude volunteerPostCodeDetails = postcodeDetails[volunteerPostCode];

            if (volunteerPostCodeDetails == null)
            {
                return jobSummaries;
            }

            foreach (JobSummary jobSummary in jobSummaries)
            {
                ILatitudeLongitude jobPostCodeDetails = postcodeDetails[jobSummary.PostCode];

                if (jobPostCodeDetails != null)
                {
                    jobSummary.DistanceInMiles = _distanceCalculator.GetDistanceInMiles(
                        volunteerPostCodeDetails.Latitude,
                        volunteerPostCodeDetails.Longitude,
                        jobPostCodeDetails.Latitude,
                        jobPostCodeDetails.Longitude);
                }
            }
            return jobSummaries;
        }

    }
}
