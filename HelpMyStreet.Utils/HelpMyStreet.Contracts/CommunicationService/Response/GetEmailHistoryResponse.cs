using System.Collections.Generic;

namespace HelpMyStreet.Contracts.CommunicationService.Response
{
    public class GetEmailHistoryResponse
    {
        public List<EmailHistory> EmailHistory { get; set; }
    }
}