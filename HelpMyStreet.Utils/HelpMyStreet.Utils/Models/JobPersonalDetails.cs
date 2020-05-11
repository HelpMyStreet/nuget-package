using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class JobPersonalDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Address Address { get; set; }
        public ContactNumber ContactNumbers { get; set; }
        public bool ConsentForContact { get; set; }
    }
}
