using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class LocationDetails : IContainsLocation
    {
        public Location Location { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public Address Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public LocationInstructions LocationInstructions { get; set; }

        public LocationDetails GetLocationDetails()
        {
            return this;
        }
    }
}
