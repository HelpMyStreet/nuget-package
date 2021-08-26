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

        public string GetDPSafeName(List<Enums.PersonalDetailsComponent> dataPrivacyOptions)
        {
            if (dataPrivacyOptions.Contains(Enums.PersonalDetailsComponent.FirstName) && dataPrivacyOptions.Contains(Enums.PersonalDetailsComponent.LastName))
            {
                return $"{FirstName} {LastName}";
            }
            else if (dataPrivacyOptions.Contains(Enums.PersonalDetailsComponent.FirstName))
            {
                return $"{FirstName}";
            }
            else if (dataPrivacyOptions.Contains(Enums.PersonalDetailsComponent.LastName))
            {
                return $"{LastName}";
            }

            return $"";
        }

        public Address GetDPSafeAddress(List<Enums.PersonalDetailsComponent> dataPrivacyOptions)
        {
            if (dataPrivacyOptions.Contains(Enums.PersonalDetailsComponent.Address) && dataPrivacyOptions.Contains(Enums.PersonalDetailsComponent.Postcode))
            {
                return Address;
            }
            else if (dataPrivacyOptions.Contains(Enums.PersonalDetailsComponent.Address))
            {
                return new Address() { AddressLine1 = Address.AddressLine1, AddressLine2 = Address.AddressLine2, AddressLine3 = Address.AddressLine3, Locality = Address.Locality };
            }
            else if (dataPrivacyOptions.Contains(Enums.PersonalDetailsComponent.Postcode))
            {
                return new Address() { Postcode = Address.Postcode };
            }
            else if (dataPrivacyOptions.Contains(Enums.PersonalDetailsComponent.Locality))
            {
                return new Address() { Locality = Address.Locality };
            } else
            {
                return null;
            }
        }

        public string GetDPSafeMobileNumber(List<Enums.PersonalDetailsComponent> dataPrivacyOptions)
        {
            if (dataPrivacyOptions.Contains(Enums.PersonalDetailsComponent.Phone))
            {
                return MobileNumber;
            }
            else
            {
                return "";
            }
        }

        public string GetDPSafeOtherNumber(List<Enums.PersonalDetailsComponent> dataPrivacyOptions)
        {
            if (dataPrivacyOptions.Contains(Enums.PersonalDetailsComponent.Phone))
            {
                return OtherNumber;
            }
            else
            {
                return "";
            }
        }

        public string GetDPSafeEmail(List<Enums.PersonalDetailsComponent> dataPrivacyOptions)
        {
            if (dataPrivacyOptions.Contains(Enums.PersonalDetailsComponent.Email))
            {
                return EmailAddress;
            }
            else
            {
                return "";
            }
        }

        public PersonalDetails GetDPSafePersonalDetails(List<Enums.PersonalDetailsComponent> dataPrivacyOptions)
        {
            return new PersonalDetails()
            {
                Address = GetDPSafeAddress(dataPrivacyOptions),
                EmailAddress = GetDPSafeEmail(dataPrivacyOptions),
                FirstName = dataPrivacyOptions.Contains(Enums.PersonalDetailsComponent.FirstName) ? FirstName : "",
                LastName = dataPrivacyOptions.Contains(Enums.PersonalDetailsComponent.LastName) ? LastName : "",
                MobileNumber = GetDPSafeMobileNumber(dataPrivacyOptions),
                OtherNumber = GetDPSafeOtherNumber(dataPrivacyOptions),
            };
        }
    }
}
