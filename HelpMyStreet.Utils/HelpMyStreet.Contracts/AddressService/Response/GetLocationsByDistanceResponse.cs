using System.Collections.Generic;

namespace HelpMyStreet.Contracts.AddressService.Response
{
   
    public class GetLocationsByDistanceResponse
    {
        public List<LocationDistance> LocationDistances { get; set; }
    }
}
