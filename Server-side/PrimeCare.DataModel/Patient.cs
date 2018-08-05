using System.Collections.Generic;

namespace DataStructure
{
    public class PatientScreen
    {
        private List<Patient> patientList = new List<Patient>();
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }


        public List<Patient> PatientList
        {
            get { return patientList; }
            set { patientList = value; }
        }
        public void Add(Patient pat)
        {
            patientList.Add(pat);
        }

    }
   public class Patient
    {
        private string _Color1 = "rgb(250, 192, 144)";
        private string _Color2 = "rgb(195, 214, 155)";
        private string _Color3 = "rgb(147, 205, 221)";
        private string _Color4 = "rgb(196, 189, 151)";

        private string patientId;
        private string[] info;
        private string location;
        private string disposition;
        private string surgeonName;
        private string anestheoiligist;
        private string procedure;
        private string startTime;
        private string status;
        private string consent;
        private string hp;
        private string xray;
        private string lab;
        private string ekg;
        private string color;

        public string StatusColor
        {
            get { return color; }
            set { color = value; }
        }


        public string EKG
        {
            get { return ekg; }
            set { ekg = value; }
        }

        public string Lab
        {
            get { return lab; }
            set { lab = value; }
        }

        public string XRay
        {
            get { return xray; }
            set { xray = value; }
        }

        public string HP
        {
            get { return hp; }
            set { hp = value; }
        }

        public string Consent
        {
            get { return consent; }
            set { consent = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value;
                setColor();
            }
        }

        private void setColor()
        {
            // set color
            if (this.Status.ToLower() == "not admitted" || this.Status.ToLower() == "admitted")
            {
                StatusColor = _Color1;
            }
            else if (this.Status.ToLower() == "in preop")
            {
                StatusColor = _Color2;
            }
            else if (this.Status.ToLower() == "in or" || this.Status.ToLower() == "induction" || this.Status.ToLower() == "positioning" || this.Status.ToLower() == "procedure started" ||
                this.Status.ToLower() == "closing" || this.Status.ToLower() == "procedure ended" || this.Status.ToLower() == "emergence" || this.Status.ToLower() == "leave or"
                || this.Status.ToLower() == "in room")
            {
                StatusColor = _Color3;
            }
            else
            {
                StatusColor = _Color4;
            }
        }

        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }


        public string Procedure
        {
            get { return procedure; }
            set { procedure = value; }
        }

        public string Anesthologist
        {
            get { return anestheoiligist; }
            set { anestheoiligist = value; }
        }


        public string SurgeonName
        {
            get { return surgeonName; }
            set { surgeonName = value; }
        }

        public string Disposition
        {
            get { return disposition; }
            set { disposition = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string[] Info
        {
            get { return info; }
            set { info = value; }
        }

        public string PatientID
        {
            get { return patientId; }
            set { patientId = value; }
        }

    }
}
