﻿using HelpMyStreet.Utils.Enums;
using System;

namespace HelpMyStreet.Utils.Models
{
    public class JobBasic
    {
        public DateTime DateStatusLastChanged { get; set; }
        public DateTime DateRequested { get; set; }
        public int RequestID { get; set; }
        public RequestType RequestType { get; set; }
        public int ReferringGroupID { get; set; }
        public int JobID { get; set; }
        public int? VolunteerUserID { get; set; }
        public SupportActivities SupportActivity { get; set; }
        public JobStatuses JobStatus { get; set; }
        public double DistanceInMiles { get; set; }
        public DateTime DueDate { get; set; }
        public bool Archive { get; set; }
        public string HmsReference { get; set; }
    }
}
