using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;

namespace HelpMyStreet.Utils.Models
{
    public class Shift
    {
        public int RequestID { get; set; }
        public DateTime StartDate { get; set; }
        public int ShiftLength { get; set; }
        public DateTime EndDate
        {
            get
            {
                return StartDate.AddMinutes(ShiftLength);
            }
        }
    }
}
