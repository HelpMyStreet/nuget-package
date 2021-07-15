using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpMyStreet.Utils.Models;

namespace HelpMyStreet.Contracts.RequestService.Response
{
    public class GetAllJobsByFilterResponse
    {
        public List<JobSummary> JobSummaries { get; set; }

        public List<ShiftJob> ShiftJobs { get; set; }

        public List<JobBasic> JobBasics
        {
            get
            {
                return JobSummaries.Cast<JobBasic>()
                    .Concat(ShiftJobs.Cast<JobBasic>()).ToList();
            }
        }
    }
}
