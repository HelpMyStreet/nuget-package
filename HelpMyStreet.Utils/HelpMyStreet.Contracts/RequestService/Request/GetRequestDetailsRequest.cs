using MediatR;
using HelpMyStreet.Contracts.RequestService.Response;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class GetRequestDetailsRequest : IRequest<GetRequestDetailsResponse>
    {
        public int AuthorisedByUserID { get; set; }
        public int RequestID { get; set; }
    }
}
