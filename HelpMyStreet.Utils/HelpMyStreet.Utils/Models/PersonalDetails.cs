using System;
using System.Collections.Generic;

namespace HelpMyStreet.Utils.Models
{
    public class PersonalDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Address Address { get; set; }
        public string MobileNumber { get; set; }
        public string OtherNumber { get; set; }

        public string GetDPSafeName(List<Enums.DataPrivacyOptions> dataPrivacyOptions)
        {
            if (dataPrivacyOptions.Contains(Enums.DataPrivacyOptions.FirstName) && dataPrivacyOptions.Contains(Enums.DataPrivacyOptions.LastName))
            {
                return $"{FirstName} {LastName}";
            }
            else if (dataPrivacyOptions.Contains(Enums.DataPrivacyOptions.FirstName))
            {
                return $"{FirstName}";
            }
            else if (dataPrivacyOptions.Contains(Enums.DataPrivacyOptions.LastName))
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
            }
            else if (dataPrivacyOptions.Contains(Enums.DataPrivacyOptions.Postcode))
            {
                return new Address() { Postcode = Address.Postcode };
            }
            else
            {
                return new Address() { Locality = Address.Locality };
            }
        }

        public string GetDPSafeMobileNumber(List<Enums.DataPrivacyOptions> dataPrivacyOptions)
        {
            if (dataPrivacyOptions.Contains(Enums.DataPrivacyOptions.Phone))
            {
                return MobileNumber;
            }
            else
            {
                return "";
            }
        }

        public string GetDPSafeOtherNumber(List<Enums.DataPrivacyOptions> dataPrivacyOptions)
        {
            if (dataPrivacyOptions.Contains(Enums.DataPrivacyOptions.Phone))
            {
                return OtherNumber;
            }
            else
            {
                return "";
            }
        }

        public string GetDPSafeEmail(List<Enums.DataPrivacyOptions> dataPrivacyOptions)
        {
            if (dataPrivacyOptions.Contains(Enums.DataPrivacyOptions.Email))
            {
                return EmailAddress;
            }
            else
            {
                return "";
            }
        }

        public PersonalDetails GetDPSafePersonalDetails(List<Enums.DataPrivacyOptions> dataPrivacyOptions)
        {
            return new PersonalDetails()
            {
                Address = GetDPSafeAddress(dataPrivacyOptions),
                EmailAddress = GetDPSafeEmail(dataPrivacyOptions),
                FirstName = dataPrivacyOptions.Contains(Enums.DataPrivacyOptions.FirstName) ? FirstName : "",
                LastName = dataPrivacyOptions.Contains(Enums.DataPrivacyOptions.LastName) ? LastName : "",
                MobileNumber = GetDPSafeMobileNumber(dataPrivacyOptions),
                OtherNumber = GetDPSafeOtherNumber(dataPrivacyOptions),
            };
        }
    }
}
