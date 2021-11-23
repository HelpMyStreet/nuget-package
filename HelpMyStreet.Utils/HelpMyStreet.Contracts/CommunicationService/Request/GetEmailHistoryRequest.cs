using HelpMyStreet.Contracts.CommunicationService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.CommunicationService.Request
{
    public class GetEmailHistoryRequest : IRequest<GetEmailHistoryResponse>
    {
        public int RequestId { get; set; }
    }
}
