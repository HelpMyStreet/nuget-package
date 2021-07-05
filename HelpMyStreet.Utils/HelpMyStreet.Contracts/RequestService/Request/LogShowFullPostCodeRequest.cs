using HelpMyStreet.Contracts.RequestService.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class LogShowFullPostCodeRequest : IRequest<LogShowFullPostCodeResponse>
    {
        public int UserID { get; set; }
        public int JobID { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
