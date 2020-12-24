using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using HelpMyStreet.Contracts.RequestService.Response;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class GetUserShiftsRequest : IRequest<GetUserShiftsResponse>
    {
        public int VolunteerUserId { get; set; }
        public int AuthorisedByUserId { get; set; }
        public JobStatusRequest JobStatusRequest { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
