using MediatR;
using HelpMyStreet.Contracts.RequestService.Response;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class GetRequestSummaryRequest : IRequest<GetRequestSummaryResponse>
    {
        public int AuthorisedByUserID { get; set; }
        public int RequestID { get; set; }
    }
}
