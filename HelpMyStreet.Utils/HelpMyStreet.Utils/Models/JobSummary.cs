using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace HelpMyStreet.Utils.Models
{
    public class JobSummary : JobHeader, IContainsLocation
    {     
        public string Details { get; set; }
        public List<Question> Questions { get; set; }
        public List<int> Groups { get; set; }
        public string RecipientOrganisation { get; set; }
        public int DueDays { get; set; }
        public bool ConsentForContact { get; set; }
        public RequestorType RequestorType { get; set; }
    }
}
