using HelpMyStreet.Utils.Models;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HelpMyStreet.Contracts.UserService.Response
{
    [DataContract(Name = "getHelperCoordsByPostcodeAndRadiusResponse")]
    public class GetVolunteerCoordinatesResponse
    {
        [DataMember(Name = "volunteerCoordinates")]
        public IReadOnlyList<VolunteerCoordinate> Coordinates { get; set; }

        [DataMember(Name = "numberOfHelpers")]
        public int NumberOfHelpers { get; set; }

        [DataMember(Name = "numberOfStreetChampions")]
        public int NumberOfStreetChampions { get; set; }

        [DataMember(Name = "totalNumberOfVolunteers")]
        public int TotalNumberOfVolunteers { get; set; }
    }
}
