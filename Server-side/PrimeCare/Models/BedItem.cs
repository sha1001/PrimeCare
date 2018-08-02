using Antlr.Runtime.Misc;

namespace PrimeCare.Models
{
    public class BedItem
    {
        public string Name { get; set; }

        public string EstDischargeTime { get; set; }

        public string Color { get; set; }

        public int  RX { get; set; }

        public PatientSummary Patient { get; set; }
    }
}