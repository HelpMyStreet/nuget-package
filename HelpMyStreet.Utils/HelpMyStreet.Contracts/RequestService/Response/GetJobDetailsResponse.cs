using System;
using System.Collections.Generic;
using System.Text;
using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Models;

namespace HelpMyStreet.Contracts.RequestService.Response
{
    public class GetJobDetailsResponse
    {
        public RequestSummary RequestSummary { get; set; }
        public JobSummary JobSummary { get; set; }
        public RequestPersonalDetails Requestor { get; set; }
        public RequestPersonalDetails Recipient { get; set; }
        public List<StatusHistory> History { get; set; }
    }
}
