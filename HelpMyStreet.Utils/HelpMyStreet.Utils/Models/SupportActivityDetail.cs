using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class SupportActivityDetail
    {
        public SupportActivities SupportActivity { get; set; }
        public string Label { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsPreSelected { get; set; }
    }
}
