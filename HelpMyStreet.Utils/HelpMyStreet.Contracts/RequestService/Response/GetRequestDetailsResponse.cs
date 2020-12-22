using HelpMyStreet.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Response
{
    public class GetRequestDetailsResponse
    {
        public Shift Shift { get; set; }
        public List<ShiftJobSummary> ShiftJobSummaries { get; set; }
    }
}
