using System.Collections.Generic;

namespace DataStructure
{
   public class BedItem
    {
        private string color_Empty = "rgb(196, 189, 151)";
        private string color_Occupied = "rgb(195, 214, 155)";
        private string color_Ready_Discharge = "rgb(250, 192, 144)";
        public string Name { get; set; }
        public string PatientID { get; set; }
        private string status;
        public int RX { get; set; }
        private PatientInfo patient;

        public PatientInfo Patient
        {
            get { return patient; }
            set { patient = value; }
        }

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (status.ToLower() == "empty")
                {
                    this.Color = color_Empty;
                }
                else if(status.ToLower() == "ready for discharge")
                {
                    this.Color = color_Ready_Discharge;
                }
                else
                {
                    this.Color = color_Occupied;
                }
            }
        }

        public string EstDischargeTime   { get; set; }
        public string Color { get; set; }
    }
    public class OperationBed
    {
        private List<BedItem> beds = new List<BedItem>();

        public List<BedItem> Beds
        {
            get { return beds; }
            set { beds = value; }
        }
        public void Add(BedItem bedItem)
        {
            beds.Add(bedItem);
        }

    }

    public class ResourceScreen
    {
        public int Id { get; set; }
        public string CurrentOccupancy { get; set; }
        public int BedOccupied { get; set; }
        public int BedEmpty { get; set; }


        private List<OperationBed> operationBeds = new List<OperationBed>();

        public List<OperationBed> OperationBeds
        {
            get { return operationBeds; }
            set { operationBeds = value; }
        }

        public void Add(OperationBed opBed)
        {
            operationBeds.Add(opBed);
        }
    }
}
