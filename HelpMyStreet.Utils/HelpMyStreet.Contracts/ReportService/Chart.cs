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

        [JsonIgnore]
        public IEnumerable<string> XAxisValues
        {
            get
            {
                return DataPoints.Select((Value, Index) => (Value, Index)).OrderBy(x => x.Index)
                        .Select(x => ConvertToFriendlyXAxisValue(x.Value.XAxis))
                        .Distinct();                
            }
        }

        [JsonIgnore]
        public IEnumerable<string> LegendItems
        {
            get
            {
                return DataPoints.Select((Value, Index) => (Value, Index)).OrderBy(x => x.Index)
                        .Select(x => x.Value.Series)
                        .Distinct();
            }
        }

        private string ConvertToFriendlyXAxisValue(string xAxis)
        {
            DateTime dt;

            try
            {
                dt = DateTime.Parse(xAxis);
                return $"{dt: MMM} '{dt:yy}";
            }
            catch (FormatException exc)
            {
                return xAxis;
            }
        }

    }
}
