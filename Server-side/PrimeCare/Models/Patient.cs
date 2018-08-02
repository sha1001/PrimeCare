using System.Collections.Generic;

namespace PrimeCare.Models
{
    public class Patient
    {
        public string StatusColor { get; set; }

        public string EKG { get; set; }

        public string Lab { get; set; }

        public string XRay { get; set; }

        public string HP { get; set; }

        public string Consent { get; set; }

        public string Status { get; set; }

        public string StartTime { get; set; }

        public string Procedure { get; set; }

        public string Anesthologist { get; set; }

        public string SurgeonName { get; set; }

        public string Disposition { get; set; }

        public string Location { get; set; }

        public List<string> Info { get; set; }

        public string PatientID { get; set; }
    }
}
