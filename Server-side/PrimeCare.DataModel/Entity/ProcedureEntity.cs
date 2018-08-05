using System;

namespace DataStructure.Entity
{
   public class ProcedureEntity
    {
        public string ProcedureId { get; set; }
        public string ProcedureType { get; set; }
        public string Status { get; set; }
        public string SpecialEquipCodes { get; set; }

        public DateTime StartPoint { get; set; }
        public DateTime EndPoint { get; set; }
        public DateTime ScheduleStartTime { get; set; } 
        public DateTime ScheduleEndTime { get; set; }
        public DateTime ProcedureStartTime { get; set; }
        public DateTime ProcedureEndTime { get; set; }
        public DateTime CurrentTime { get; set; }
        public string MRN { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SurgeonFirstName { get; set; }
        public string SurgeonLastName { get; set; }
        public string AnestFirstName { get; set; }
        public string AnestLastName { get; set; }
        public string CrnaFirstName { get; set; }
        public string CrnaLastName { get; set; }
        public string NuresFirstName { get; set; }
        public string NurseLastName { get; set; }
        public string ORName { get; set; }
        public Int32 ORId { get; set; }
    }
}
