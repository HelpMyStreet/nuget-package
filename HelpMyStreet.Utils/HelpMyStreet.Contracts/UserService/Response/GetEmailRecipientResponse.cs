using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.UserService.Response
{
    public class GetEmailRecipientResponse
    {
        public IEnumerable<EmailRecipient> EmailRecipients { get; set; }
    }
}
