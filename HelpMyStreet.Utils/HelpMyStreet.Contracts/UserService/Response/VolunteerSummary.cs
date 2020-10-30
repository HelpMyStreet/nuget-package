using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.UserService.Response
{
    public class VolunteerSummary
    {
        public int UserID { get; set; }
        public double DistanceInMiles { get; set; }
    }
}
