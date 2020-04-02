using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class UserPersonalDetails
    {
        public User User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Address Address { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }
        public string OtherPhone { get; set; }
    }
}
