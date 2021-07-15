using HelpMyStreet.Contracts.AddressService.Response;
using HelpMyStreet.Utils.Enums;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelpMyStreet.Contracts.AddressService.Request
{
    public class LocationsRequest
    {
        public List<Location> Locations { get; set; }
    }

    public class GetLocationsRequest : IRequest<GetLocationsResponse>
    {
        public LocationsRequest LocationsRequests { get; set; }
    }
}
