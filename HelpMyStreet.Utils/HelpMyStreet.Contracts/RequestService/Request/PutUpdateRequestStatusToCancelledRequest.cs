using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class PutUpdateRequestStatusToCancelledRequest
    {
        public int RequestID { get; set; }
        public int CreatedByUserID { get; set; }
    }
}
