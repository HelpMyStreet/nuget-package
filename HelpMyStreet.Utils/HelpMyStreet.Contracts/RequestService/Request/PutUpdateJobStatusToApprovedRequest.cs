using HelpMyStreet.Contracts.RequestService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class PutUpdateJobStatusToApprovedRequest : IRequest<PutUpdateJobStatusToApprovedResponse>
    {
        public int JobID { get; set; }
        public int CreatedByUserID { get; set; }
        public int VolunteerUserID { get; set; }
    }
}
