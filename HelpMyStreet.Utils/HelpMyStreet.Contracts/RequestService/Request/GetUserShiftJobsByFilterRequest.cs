using HelpMyStreet.Contracts.RequestService.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class GetUserShiftJobsByFilterRequest : IRequest<GetUserShiftJobsByFilterResponse>
    {
        public int VolunteerUserId { get; set; }
        public JobStatusRequest JobStatusRequest { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
