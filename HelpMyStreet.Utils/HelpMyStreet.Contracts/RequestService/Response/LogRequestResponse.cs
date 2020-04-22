using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Response
{
    public class LogRequestResponse
    {
        public int RequestID { get; set; }
        public bool Fulfillable { get; set; }
    }
}
