using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class SupportActivityConfiguration
    {
        public SupportActivities SupportActivity { get; set; }
        public bool AutoSignUpWhenOtherSelected { get; set; }
    }
}
