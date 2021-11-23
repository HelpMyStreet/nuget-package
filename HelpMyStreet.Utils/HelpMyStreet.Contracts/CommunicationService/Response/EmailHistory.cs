using System;

namespace HelpMyStreet.Contracts.CommunicationService.Response
{
    public class EmailHistory
    {
        public int RecipientCount { get; set; }
        public string EmailType { get; set; }
        public DateTime DateSent { get; set; }
        public string Event { get; set; }
    }
}