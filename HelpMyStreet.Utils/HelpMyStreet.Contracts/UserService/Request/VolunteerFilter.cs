using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class VolunteerFilter
    {
        public string Postcode { get; set; }
        public SupportActivities Activity { get; set; }
    }
}
