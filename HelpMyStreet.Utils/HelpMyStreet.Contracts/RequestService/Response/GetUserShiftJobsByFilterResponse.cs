using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Response
{
    public class GetUserShiftJobsByFilterResponse
    {
        public List<ShiftJob> ShiftJobs { get; set; }
    }
}
