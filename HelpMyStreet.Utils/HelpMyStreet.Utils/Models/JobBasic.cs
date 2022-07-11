using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Extensions;
using System;
using System.Globalization;

namespace HelpMyStreet.Utils.Models
{
    public class JobBasic
    {
        public DateTime DateStatusLastChanged { get; set; }
        public DateTime DateRequested { get; set; }
        public int RequestID { get; set; }
        public RequestType RequestType { get; set; }
        public int ReferringGroupID { get; set; }
        public string Source { get; set; }
        public int JobID { get; set; }
        public int? VolunteerUserID { get; set; }
        public SupportActivities SupportActivity { get; set; }
        public JobStatuses JobStatus { get; set; }
        public double DistanceInMiles { get; set; }
        public DateTime DueDate { get; set; }
        public DueDateType DueDateType { get; set; }
        public DateTime? NotBeforeDate { get; set; }
        public bool Archive { get; set; }
        public string HmsReference { get => GetHmsReference(); }
        public bool? SuppressRecipientPersonalDetail { get; set; }
        public string SpecificSupportActivity { get; set; }

        private string GetHmsReference()
        {
            Groups thisGroup = (Groups)ReferringGroupID;

            return $"{thisGroup.GroupIdentifier()}-{DateRequested:yyMMdd}-{RequestID % 1000}";

        }

        public string GetSupportActivityName
        {
            get
            {
                switch (SupportActivity)
                {
                    case SupportActivities.AdvertisingRoles:
                    case SupportActivities.Other:
                        if (!string.IsNullOrEmpty(SpecificSupportActivity))
                        {
                            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                            return ti.ToTitleCase(SpecificSupportActivity);
                        }
                        else
                        {
                            return SupportActivity.FriendlyNameShort();
                        }
                    default:
                        return SupportActivity.FriendlyNameShort();
                };
            }
        }

    }
}
