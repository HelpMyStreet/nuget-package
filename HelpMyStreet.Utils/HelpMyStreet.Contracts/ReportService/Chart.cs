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
        public string Title { get; set; }
        public ChartTypes ChartType { get; set; }
        public string XAxisName { get; set; }
        public string YAxisName { get; set; }
        public List<DataItem> ChartItems { get; set; }

        [JsonIgnore]
        public IEnumerable<string> Labels
        {
            get
            {
                return ChartItems.OrderBy(x => x.XAxis)
                .Select(x => x.XAxis)
                .Distinct();
            }
        }
        
    }
}
