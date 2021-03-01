using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class UserPersonalDetails
    {
        public User User { get; set; }

        // Supplied in registration step 1
        public string EmailAddress { get; set; }


        // Supplied in registration step 2
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string MobilePhone { get; set; }
        public string OtherPhone { get; set; }
        public DateTime? DateOfBirth { get; set; }

        // Defaulted to FirstName following step 2
        public string DisplayName { get; set; }


        // Supplied in registration step 3
        public bool? UnderlyingMedicalCondition { get; set; }

        public string GetDPSafeName(List<Enums.DataPrivacyOptions> dataPrivacyOptions, bool displayNameOnly)
        {
            if (displayNameOnly)
            {
                return $"{DisplayName}";
            }

            if (dataPrivacyOptions.Contains(Enums.DataPrivacyOptions.FirstName) && dataPrivacyOptions.Contains(Enums.DataPrivacyOptions.LastName))
            {
                return $"{FirstName} {LastName}";
            } else if (dataPrivacyOptions.Contains(Enums.DataPrivacyOptions.FirstName))
            {
                return $"{FirstName}";
            } else if (dataPrivacyOptions.Contains(Enums.DataPrivacyOptions.LastName))
            {
                return $"{LastName}";
            }

            return $"";
        }

        public Address GetDPSafeAddress(List<Enums.DataPrivacyOptions> dataPrivacyOptions)
        {
            if (dataPrivacyOptions.Contains(Enums.DataPrivacyOptions.Address) && dataPrivacyOptions.Contains(Enums.DataPrivacyOptions.Postcode))
            {
                return Address;
            } else if (dataPrivacyOptions.Contains(Enums.DataPrivacyOptions.Postcode)) {
                return new Address() { Postcode = Address.Postcode };
            } else
            {
                return new Address() { Locality = Address.Locality };
            }
        }
    }
}
