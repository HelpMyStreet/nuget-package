using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirebaseUID { get; set; }
        public string PostalCode { get; set; }
        public bool EmailSharingConsent { get; set; }
        public bool MobileSharingConsent { get; set; }
        public bool OtherPhoneSharingConsent { get; set; }
        public bool HMSContactConsent { get; set; }
        public bool IsVolunteer { get; set; }
        public bool IsVerified { get; set; }
        public DateTime DateCreated { get; set; }
        public UserPersonalDetails UserPersonalDetails { get; set; }
        public Dictionary<int, DateTime> RegistrationHistory { get; set; }
    }
}
