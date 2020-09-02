using MediatR;
using HelpMyStreet.Contracts.RequestService.Response;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class GetJobSummaryRequest : IRequest<GetJobSummaryResponse>
    {
        public int JobID { get; set; }
    }
}
