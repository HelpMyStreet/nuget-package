using HelpMyStreet.Contracts.AddressService.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HelpMyStreet.Contracts.AddressService.Request
{
    public class GetLocationRequest : IRequest<GetLocationResponse>
    {
        public LocationRequest LocationRequest { get; set; }
    }
}
