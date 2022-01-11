using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetGroupNewRequestNotificationStrategyResponse
    {
        public int MaxVolunteer { get; set; }
        public NewRequestNotificationStrategy NewRequestNotificationStrategy { get; set; }
    }
}
