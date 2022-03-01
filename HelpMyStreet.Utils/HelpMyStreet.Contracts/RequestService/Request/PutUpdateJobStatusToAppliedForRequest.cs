using HelpMyStreet.Contracts.RequestService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class PutUpdateJobStatusToAppliedForRequest : IRequest<PutUpdateJobStatusToAppliedForResponse>
    {
        public int JobID { get; set; }
        public int CreatedByUserID { get; set; }
        public int VolunteerUserID { get; set; }
    }
}
