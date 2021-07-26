using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class GroupSupportActivityRadius
    {
        public Groups Group { get; set; }
        public SupportActivities SupportActivity { get; set; }
        public double? SupportRadiusMiles { get; set; }
    }
}
