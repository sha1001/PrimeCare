using System.Collections.Generic;

namespace PrimeCare.Models
{
    public class Resources
    {
        public int Id { get; set; }

        public string CurrentOccupancy { get; set; }

        public int BedOccupied { get; set; }

        public string BedEmpty { get; set; }

        public List<OperationBed> OperationBeds { get; set; }
    }
}
