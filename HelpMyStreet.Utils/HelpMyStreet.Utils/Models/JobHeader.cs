using HelpMyStreet.Utils.Enums;
using System;

namespace HelpMyStreet.Utils.Models
{
    public class JobHeader : JobBasic, IContainsLocation
    {
        public string PostCode { get; set; }
        public bool IsHealthCritical { get; set; }
        public string Reference { get; set; }
        public bool RequestorDefinedByGroup { get; set; }

        public LocationDetails GetLocationDetails()
        {
            return new LocationDetails() { Address = new Address() { Postcode = PostCode } };
        }
    }
}
