using MediatR;
using System;

namespace HelpMyStreet.Contracts.CommunicationService.Request
{
    public class InterUserMessageRequest : IRequest<bool>
    {
        public Guid ThreadId { get; set; }
        public MessageParticipant From { get; set; }
        public MessageParticipant To { get; set; }
        public int? JobId { get; set; }
        public string Content { get; set; }
    }
}