using System.Collections.Generic;

namespace PrimeCare.Models
{
    public class PACUThroughChart
    {
        public List<int> PacuThChartdataset { get; set; }

        public string PacuThChartdatasetlabel { get; set; }

        public List<string> PacuThChartlabels { get; set; }

        public List<string> PacuThChartbackgroundColor { get; set; }
    }
}