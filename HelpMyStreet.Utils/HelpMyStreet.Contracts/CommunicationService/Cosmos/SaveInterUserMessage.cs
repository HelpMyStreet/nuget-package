using System;

namespace HelpMyStreet.Contracts.CommunicationService.Cosmos
{
    public class SaveInterUserMessage
    {
        public Guid ThreadId { get; set; }
        public SaveMessageParticipant From { get; set; }
        public SaveMessageParticipant To { get; set; }
        public int? JobId { get; set; }
        public string Content { get; set; }
    }
}