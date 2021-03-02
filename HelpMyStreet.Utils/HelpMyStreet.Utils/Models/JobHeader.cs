using HelpMyStreet.Utils.Enums;
using System;

namespace HelpMyStreet.Utils.Models
{
    public class JobHeader : JobBasic
    {
        public DateTime DateRequested { get; set; }
        public DateTime DateStatusLastChanged { get; set; }        
        public string PostCode { get; set; }
        public bool IsHealthCritical { get; set; }
        public DateTime DueDate { get; set; }
        public bool? Archive { get; set; }
        public string Reference { get; set; }
        public DueDateType DueDateType { get; set; }
        public bool RequestorDefinedByGroup { get; set; }
    }
}
