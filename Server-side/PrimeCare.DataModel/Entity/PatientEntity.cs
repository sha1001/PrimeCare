using System;

namespace DataStructure.Entity
{
   public class PatientEntity
    {
        public Int32 ID { get; set; }
        public string ORName { get; set; }
        public string Disposition { get; set; }
        public string SurgeonFirstName { get; set; }
        public string SurgeonLastName { get; set; }
        public string AnestFirstName { get; set; }
        public string AnestLastName { get; set; }
        public string ProcedureName { get; set; }
        public string Status { get; set; }
        public DateTime StartTime { get; set; }
        public string ConsentStatus { get; set; }
        public string HPstatus { get; set; }
        public string XRayStatus { get; set; }
        public string LabsStatus { get; set; }
        public string EKGStatus { get; set; }
    }
}
