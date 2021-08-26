using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class LocationInstructions
    {
        public string Intro { get; set; }
        public List<Step> Steps { get; set; }
        public string Close { get; set; }
    }
}
