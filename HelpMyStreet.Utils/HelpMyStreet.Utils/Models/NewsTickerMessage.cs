using HelpMyStreet.Utils.Enums;
using System;

namespace HelpMyStreet.Utils.Models
{
    public class NewsTickerMessage
    {
        public string Message { get; set; }
        public SupportActivities? SupportActivity { get; set; }
        public double? Value { get; set; }
    }


}