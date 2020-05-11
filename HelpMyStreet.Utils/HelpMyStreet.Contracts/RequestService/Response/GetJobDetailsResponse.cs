using System;
using System.Collections.Generic;
using System.Text;
using HelpMyStreet.Utils.Models;

namespace HelpMyStreet.Contracts.RequestService.Response
{
    public class GetJobDetailsResponse
    {
        public HelpRequest HelpRequest { get; set; }
        public Job Job { get; set; }
    }
}
