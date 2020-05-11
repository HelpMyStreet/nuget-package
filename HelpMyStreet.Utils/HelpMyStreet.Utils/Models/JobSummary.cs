﻿using HelpMyStreet.Contracts.RequestService.Response;
using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class JobSummary
    {
        public int JobID { get; set; }
        public Guid UniqueIdentifier { get; set; }
        public JobStatuses JobStatus { get; set; }
        public int? VolunteerUserID { get; set; }
        public SupportActivities SupportActivity { get; set; }
        public string Details { get; set; }
        public DateTime DueDate { get; set; }
        public bool Critical { get; set; }
        public string PostCode { get; set; }
    }
}
