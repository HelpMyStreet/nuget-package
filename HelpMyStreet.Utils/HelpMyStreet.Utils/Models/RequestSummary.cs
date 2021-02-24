﻿using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class RequestSummary
    {
        public Shift Shift { get; set; }
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
        public int RequestID { get; set; }
        public RequestType RequestType { get; set; }
        public int ReferringGroupID { get; set; }
        public DateTime DateRequested { get; set; }
        public string PostCode { get; set; }
    }
}
