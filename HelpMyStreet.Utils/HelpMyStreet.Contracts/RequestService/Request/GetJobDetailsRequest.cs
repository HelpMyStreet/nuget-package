using MediatR;
using HelpMyStreet.Contracts.RequestService.Response;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class GetJobDetailsRequest : IRequest<GetJobDetailsResponse>
    {
        public int UserID { get; set; }
        public int JobID { get; set; }
    }
}
