using System;

namespace DataStructure.Entity
{
   public class ResourceEntity
    {
        public string BedName { get; set; }
        public int ID { get; set; }
        public string Status { get; set; }
        public DateTime PacuAdmitTime { get; set; }
        public DateTime PacuDischargeTime { get; set; }
        public DateTime CurrentTime { get; set; }
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
    }
}
