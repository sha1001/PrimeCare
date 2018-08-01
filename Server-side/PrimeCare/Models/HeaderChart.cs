using System.Collections.Generic;

namespace PrimeCare.Models
{
    public class HeaderChart
    {
        public List<int> hchartdataset { get; set; }

        public string hchartdatasetlabel { get; set; }

        public List<string> hchartlabels { get; set; }

        public List<string> hchartbackgroundColor { get; set; }
    }
}
