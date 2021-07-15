using HelpMyStreet.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Response
{
    public class GetRequestsByFilterResponse
    {        
        public List<RequestSummary> RequestSummaries { get; set; }
    }
}
