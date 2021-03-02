using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Models
{
    public class JobBasic
    {
        public int RequestID { get; set; }
        public RequestType RequestType { get; set; }
        public int ReferringGroupID { get; set; }
        public int JobID { get; set; }
        public int? VolunteerUserID { get; set; }
        public SupportActivities SupportActivity { get; set; }
        public JobStatuses JobStatus { get; set; }
        public double DistanceInMiles { get; set; }
    }
}
