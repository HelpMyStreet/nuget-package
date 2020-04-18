using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HelpMyStreet.Contracts.AddressService.Response
{
    [DataContract(Name = "isPostcodeWithinRadiiResponse")]
    public class IsPostcodeWithinRadiiResponse
    {
        [DataMember(Name = "idsWithinRadius")]
        public IReadOnlyList<int> IdsWithinRadius { get; set; }
    }
}
