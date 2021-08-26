using HelpMyStreet.Contracts.AddressService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.AddressService.Request
{
    public class GetLocationsByDistanceRequest : IRequest<GetLocationsByDistanceResponse>
    {
        public string Postcode { get; set; }
        public int MaxDistance { get; set; }
    }
}
