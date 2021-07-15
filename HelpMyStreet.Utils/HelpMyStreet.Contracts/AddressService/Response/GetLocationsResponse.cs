using HelpMyStreet.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.AddressService.Response
{
    public class GetLocationsResponse
    {
        public List<LocationDetails> LocationDetails { get; set; }
    }
}
