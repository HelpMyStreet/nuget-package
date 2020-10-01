using HelpMyStreet.Contracts.CommunicationService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.CommunicationService.Request
{
    public class GetLinkDestinationRequest : IRequest<GetLinkDestinationResponse>
    {
        public string Token { get; set; }
    }
}
