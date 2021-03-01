using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpMyStreet.Utils.Extensions;

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


        public IEnumerable<string> PhoneNumbers()
        {
            return (new[] { MobileNumber, OtherNumber }).Where(a => !string.IsNullOrEmpty(a));
        }

        public string CommaSeparatedAddress()
        {
            if (Address != null)
            {
                string[] elements = new[]
                {
                Address.AddressLine1,
                Address.AddressLine2,
                Address.AddressLine3,
                Address.Locality.ToTitleCase(),
                Address.Postcode
            };

                return string.Join(", ", elements.Where(e => !string.IsNullOrEmpty(e)));
            } else
            {
                return "";
            }
        }

        public string FullName(bool lastnameFirst = false)
        {
            if (!String.IsNullOrEmpty(FirstName) && !String.IsNullOrEmpty(LastName))
            {
                
                return lastnameFirst ? $"{LastName}, {FirstName}" : $"{FirstName} {LastName}";
            }
            else if (!String.IsNullOrEmpty(FirstName) )
            {
                return FirstName;
            } else
            {
                return LastName;
            }
        }

        public string LocationSummary()
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(Address.Locality))
            {
                sb.Append(Address.Locality.ToTitleCase());
            }

            if (!string.IsNullOrEmpty(Address.Postcode))
            {
                sb.Append(" (");
                sb.Append(Address.Postcode.Split(' ').First().ToUpper());
                sb.Append(")");
            }

            return sb.ToString().Trim();
        }

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
