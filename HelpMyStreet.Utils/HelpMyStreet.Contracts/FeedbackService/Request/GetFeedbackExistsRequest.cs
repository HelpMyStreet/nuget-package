using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.FeedbackService.Request
{
    public class GetFeedbackExistsRequest : IRequest<bool>
    {
        public int JobId { get; set; }
        public RequestRoleType RequestRoleType { get; set; }
        public int? UserId { get; set; }
    }
}
