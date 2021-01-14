using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Models
{
    public class JobBasic
    {
        public int ReferringGroupID { get; set; }
        public int JobID { get; set; }
        public int? VolunteerUserID { get; set; }
        public SupportActivities SupportActivity { get; set; }
        public JobStatuses JobStatus { get; set; }
    }
}
