using HelpMyStreet.Contracts.FeedbackService.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.FeedbackService.Request
{
    public class PostRecordFeedbackRequest : IRequest<PostRecordFeedbackResponse>
    {
        public int JobId { get; set; }
        public RequestRoleType RequestRoleType { get; set; }
        public int? UserId { get; set; }
        public FeedbackRatingType FeedbackRatingType { get; set; }
    }
}
