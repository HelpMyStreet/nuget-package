using HelpMyStreet.Contracts.RequestService.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class LogRequestEventRequest : IRequest<LogRequestEventResponse>
    {
        public int UserID { get; set; }
        public int? JobID { get; set; }
        public int RequestID { get; set; }
        public RequestEventRequest RequestEventRequest { get; set; }
    }
}
