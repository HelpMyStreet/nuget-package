using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class ShiftRequest
    {
        public Shift Shift { get; set; }
        public List<ShiftJobSummary> ShiftJobSummaries { get; set; }
    }
}
