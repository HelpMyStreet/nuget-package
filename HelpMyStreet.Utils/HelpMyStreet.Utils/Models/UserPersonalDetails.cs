using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class UserPersonalDetails : PersonalDetails
    {
        public User User { get; set; }
        public string MobilePhone { get => MobileNumber; set => MobileNumber = value; }
        public string OtherPhone { get => OtherNumber; set => OtherNumber = value; }
        public DateTime? DateOfBirth { get; set; }

        // Defaulted to FirstName following step 2
        public string DisplayName { get; set; }


        // Supplied in registration step 3
        public bool? UnderlyingMedicalCondition { get; set; }

        public UserPersonalDetails GetDPSafeUserPersonalDetails (List<Enums.DataPrivacyOptions> dataPrivacyOptions)
        {
            var pDetails = GetDPSafePersonalDetails(dataPrivacyOptions);
            return new UserPersonalDetails()
            {
                Address = pDetails.Address,
                EmailAddress = pDetails.EmailAddress,
                DateOfBirth = DateOfBirth,
                DisplayName = DisplayName,
                FirstName = pDetails.FirstName,
                LastName = pDetails.LastName,
                MobileNumber = pDetails.MobileNumber,
                OtherNumber = pDetails.OtherNumber,
                UnderlyingMedicalCondition = UnderlyingMedicalCondition,
                User = User
            };
        }
    }
}
