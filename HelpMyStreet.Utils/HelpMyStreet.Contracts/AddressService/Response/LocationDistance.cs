using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.AddressService.Response
{
    public class LocationDistance
    {
        public Location Location { get; set; }
        public double DistanceFromPostCode { get; set; }
    }
}
