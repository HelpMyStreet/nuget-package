using MediatR;
using HelpMyStreet.Contracts.RequestService.Response;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class GetRequestSummaryRequest : IRequest<GetRequestSummaryResponse>
    {
        public int RequestID { get; set; }
    }
}
