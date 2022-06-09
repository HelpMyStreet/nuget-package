using HelpMyStreet.Contracts.CommunicationService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.CommunicationService.Request
{
    public class GetDateEmailLastSentRequest : IRequest<GetDateEmailLastSentResponse>
    {
        public string TemplateName { get; set; }
        public int RecipientUserId { get; set; }
    }
}
