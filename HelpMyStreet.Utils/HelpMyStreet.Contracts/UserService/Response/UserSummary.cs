using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.UserService.Response
{
    public class UserSummary
    {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostCode { get; set; }
        public bool? IsVolunteer { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsStreetChampion { get; set; }
        public bool? IsStreetChampionForGivenPostCode { get; set; }

    }
}
