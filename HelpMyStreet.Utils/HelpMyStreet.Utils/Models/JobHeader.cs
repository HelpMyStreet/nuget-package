using HelpMyStreet.Utils.Enums;
using System;

namespace HelpMyStreet.Utils.Models
{
    public class JobHeader : JobBasic
    {
        public string PostCode { get; set; }
        public bool IsHealthCritical { get; set; }
        
        public string Reference { get; set; }
        public DueDateType DueDateType { get; set; }
        public bool RequestorDefinedByGroup { get; set; }
    }
}
