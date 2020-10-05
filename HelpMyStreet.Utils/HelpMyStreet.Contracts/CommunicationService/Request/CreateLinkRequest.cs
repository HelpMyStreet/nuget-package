using HelpMyStreet.Contracts.CommunicationService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.CommunicationService.Request
{
    public class CreateLinkRequest : IRequest<CreateLinkResponse>
    {
        public string LinkDestination { get; set; }
        public int ExpiryDays { get; set; }
    }
}
