using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class LocationDetails
    {
        public Location Location { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public Address Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public LocationInstructions LocationInstructions { get; set; }
    }
}
