using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetGroupNewRequestNotificationStrategyResponse
    {
        public int MaxVolunteer { get; set; }
        public NewRequestNotificationStrategy NewRequestNotificationStrategy { get; set; }
        public UrgentRequestNotificationStrategy? UrgentRequestNotificationStrategy { get; set; }
    }
}
