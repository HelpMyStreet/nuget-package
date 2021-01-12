using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Models
{
    public class ShiftJobSummary
    {     
        public int ID { get; set; }
        public int VolunteerUserID { get; set; }
        public SupportActivities Activity { get; set; }
        public JobStatuses JobStatuses { get; set; }
    }
}
