using HelpMyStreet.Utils.Enums;
using System.Collections.Generic;

namespace HelpMyStreet.Utils.Models
{
    public class Instructions
    {
        public SupportActivityInstructions SupportActivityInstructions { get; set; }
        public string ActivityDetails { get; set; }
        public string Intro { get; set; }
        public List<Step> Steps { get; set; }
        public string Close { get; set; }
    }
}
