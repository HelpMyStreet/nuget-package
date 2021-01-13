using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class LocationDetails
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public Address Address { get; set; }
        public LocationInstructions LocationInstructions { get; set; }
    }
}
