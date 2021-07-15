using HelpMyStreet.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class HelpRequestDetail
    {
        public HelpRequest HelpRequest { get; set; }
        public NewJobsRequest NewJobsRequest { get; set; }
    }
}
