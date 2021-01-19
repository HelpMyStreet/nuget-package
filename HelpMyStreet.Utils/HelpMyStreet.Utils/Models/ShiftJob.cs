﻿using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class ShiftJob : JobBasic
    {        
        public int RequestID { get; set; }
        public Location Location { get; set; }        
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