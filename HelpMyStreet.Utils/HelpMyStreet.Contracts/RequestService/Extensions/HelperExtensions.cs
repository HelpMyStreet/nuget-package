using HelpMyStreet.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Extensions
{
    public static class HelperExtensions
    {
        public static IOrderedEnumerable<JobHeader> OrderOpenJobsForDisplay(this IEnumerable<JobHeader> input)
        {
            return
              input
                .OrderBy(j => j.DueDate.Date)
                .ThenByDescending(j => j.IsHealthCritical)
                .ThenBy(j => j.DistanceInMiles);
        }  

    }
}
