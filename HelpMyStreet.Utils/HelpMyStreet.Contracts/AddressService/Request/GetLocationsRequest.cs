using HelpMyStreet.Contracts.AddressService.Response;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelpMyStreet.Contracts.AddressService.Request
{
    public class GetLocationsRequest : IRequest<GetLocationsResponse>
    {
        public List<LocationRequest> LocationRequests { get; set; }
    }
}
