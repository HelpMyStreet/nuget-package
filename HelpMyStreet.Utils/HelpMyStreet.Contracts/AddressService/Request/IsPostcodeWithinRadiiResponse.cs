using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HelpMyStreet.Contracts.AddressService.Request
{
    [DataContract(Name = "isPostcodeWithinRadiiResponse")]
    public class IsPostcodeWithinRadiiResponse
    {
        [DataMember(Name = "idsWithinRadius")]
        public IEnumerable<int> IdsWithinRadius { get; set; }
    }
}
