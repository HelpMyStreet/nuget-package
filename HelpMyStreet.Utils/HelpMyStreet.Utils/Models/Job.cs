using HelpMyStreet.Contracts.RequestService.Response;
using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class Job
    {
        public Guid Guid { get; set; }
        public int JobID { get; set; }
        public JobStatuses JobStatus { get; set; }
        public int? VolunteerUserID { get; set; }
        public SupportActivities SupportActivity { get; set; }
        public List<Question> Questions { get; set; }
        public int DueDays { get; set; }
        public bool HealthCritical { get; set; }
        public DueDateType DueDateType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? NotBeforeDate { get; set; }
        public Frequency RepeatFrequency { get; set; }
        public int NumberOfRepeats { get; set; }
    }
}
