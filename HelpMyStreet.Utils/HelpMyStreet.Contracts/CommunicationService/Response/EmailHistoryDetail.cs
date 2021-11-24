using System;

namespace HelpMyStreet.Contracts.CommunicationService.Response
{
    public class EmailHistoryDetail
    {
        public int RecipientCount { get; set; }
        public string EmailType { get; set; }
        public DateTime DateSent { get; set; }
    }
}