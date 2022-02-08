using HelpMyStreet.Utils.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelpMyStreet.Contracts.ReportService
{
    public class Chart
    {
        public string XAxisName { get; set; }
        public string YAxisName { get; set; }
        public List<DataPoint> DataPoints { get; set; }

        public IEnumerable<string> Labels2
        {
            get
            {
                return DataPoints.Select((Value, Index) => (Value, Index)).OrderBy(x => x.Index)
                        .Select(x => x.Value.XAxis)
                        .Distinct();                
            }
        }

        

        [JsonIgnore]
        public IEnumerable<string> Labels
        {
            get
            {
                return DataPoints.OrderBy(x => x.XAxis)
                .Select(x => x.XAxis)
                .Distinct();
            }
        }
        
    }
}
