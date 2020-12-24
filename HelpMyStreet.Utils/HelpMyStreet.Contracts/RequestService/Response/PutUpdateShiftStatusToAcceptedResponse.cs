using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Response
{
    public class PutUpdateShiftStatusToAcceptedResponse
    {
        public int JobID { get; set; }
        public UpdateJobStatusOutcome Outcome { get; set; }
    }
}
