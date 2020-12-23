using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class SupportActivityCountRequest
    {
        public SupportActivities SupportActivity { get; set; }
        public int Count { get; set; }
    }
}
