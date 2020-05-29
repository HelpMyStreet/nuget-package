using HelpMyStreet.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Extensions
{
    public static class LinqExtension
    {
            public static IOrderedEnumerable<JobSummary> OrderOpenJobsForDisplay(this IEnumerable<JobSummary> input)
            {
                return
                  input
                    .OrderBy(j => j.DueDate)
                    .ThenByDescending(j => j.IsHealthCritical)
                    .ThenByDescending(j => j.DistanceInMiles);
            }
        }
    
}
