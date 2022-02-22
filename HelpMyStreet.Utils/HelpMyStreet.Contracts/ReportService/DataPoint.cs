using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.ReportService
{
    public class DataPoint
    {
        public string XAxis { get; set; }
        public string Series { get; set; }
        public double Value { get; set; }
        public List<DataPointChild> Children { get; set; }
    }
}
