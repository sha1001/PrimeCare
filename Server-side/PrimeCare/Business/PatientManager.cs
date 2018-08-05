using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataStructure;
using DataStructure.Entity;
using PrimeCare.Repository;

namespace PrimeCare.Business
{
    public class PatientManager
    {
        public PatientScreen GetPatientData()
        {
            // get the Patient list entity from the database. 
            PatientRepository patientRepository = new PatientRepository();
            List<PatientEntity> list = patientRepository.LoadList(null);

            // map patientEntity to patient data model.
            if (list == null)
                return null;

            PatientScreen patientScreen = new PatientScreen();
            foreach (PatientEntity entity in list)
            {
                Patient patient = new Patient();
                patient.PatientID = entity.ID.ToString();
                patient.Location = entity.ORName;
                patient.Disposition = entity.Disposition;
                patient.SurgeonName = $"{entity.SurgeonFirstName},{entity.SurgeonLastName}";
                patient.Anesthologist = $"{entity.AnestFirstName},{entity.AnestLastName}";
                patient.Procedure = entity.ProcedureName;
                patient.StartTime = entity.StartTime.ToString("HH:mm");
                patient.Status = entity.Status;
                patient.Consent = ImageRender(entity.ConsentStatus);
                patient.HP = ImageRender(entity.HPstatus);
                patient.XRay = ImageRender(entity.XRayStatus);
                patient.Lab = ImageRender(entity.LabsStatus);
                patient.EKG = ImageRender(entity.EKGStatus);

                patientScreen.Add(patient);

            }

            return patientScreen;
        }
        private static string ImageRender(string data)
        {
            switch (data)
            {
                case "Not Complete":
                    return "notcompleted.png";

                case "Not admitted":
                    return "notadmitted.png";
                case "Complete":
                    return "completed.png";
                case "In Progress":
                    return "inprogress.png";
                case "Pending":
                    return "pending.png";
                default:
                    return "notcompleted.png";
            }
        }
    }
}