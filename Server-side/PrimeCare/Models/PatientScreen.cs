using System.Collections.Generic;

namespace PrimeCare.Models
{
    public class PatientScreen
    {
        public int ID { get; set; }

        public List<Patient> Patients { get; set; }
    }
}