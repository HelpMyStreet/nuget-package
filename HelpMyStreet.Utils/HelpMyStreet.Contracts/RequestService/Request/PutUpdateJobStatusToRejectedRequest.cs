using HelpMyStreet.Contracts.RequestService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class PutUpdateJobStatusToRejectedRequest : IRequest<PutUpdateJobStatusToRejectedResponse>
    {
        public int JobID { get; set; }
        public int CreatedByUserID { get; set; }
    }
}
