using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HelpMyStreet.Contracts.AddressService.Response
{
    [DataContract(Name = "GetDistanceBetweenPostcodesResponse")]
    public class GetDistanceBetweenPostcodesResponse
    {
        [DataMember(Name = "distanceInMiles")]
        public double DistanceInMiles { get; set; }

    }
}
