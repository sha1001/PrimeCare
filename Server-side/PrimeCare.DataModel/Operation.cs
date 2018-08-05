using System;

namespace DataStructure
{
    public class Operation
    {
        private int _stDisplayTime;
        private int _endDisplayTime;
        private int _currentTime;
        private string _Color1 = "rgb(250, 192, 144)";
        private string _Color2 = "rgb(195, 214, 155)";
        private string _Color3 = "rgb(147, 205, 221)";
        private string _Color4 = "rgb(196, 189, 151)";
        public Operation(int stDisplayTime, int endDisplayTime, string currentTime)
        {
            this._stDisplayTime = stDisplayTime;
            this._endDisplayTime = endDisplayTime + 60;
            this._currentTime = Helper.StringToIntTime(currentTime);
        }
        public Operation(string stDisplayTime, string endDisplayTime, string currentTime)
        {
            this._stDisplayTime = Helper.StringToIntTime(stDisplayTime);
            this._endDisplayTime = Helper.StringToIntTime(endDisplayTime);
            this._currentTime = Helper.StringToIntTime(currentTime);
        }
        public Operation(DateTime stDisplayTime, DateTime endDisplayTime, DateTime currentTime)
        {
            this._stDisplayTime = Helper.DateTimeToIntTime(stDisplayTime);
            this._endDisplayTime = Helper.DateTimeToIntTime(endDisplayTime);
            this._currentTime = Helper.DateTimeToIntTime(currentTime);
        }
        private string  id; // ProcedureId
        private string opName; // ProcType
        private string status; // ProcStatus
        private string imageName; // SpecialEquipCodes
        private string schStartTime; // SchedStartDTTM
        private string schEndTime; // SchedEndDTTM
        private int startDelay;  // Missing
        private int endDelay; // Missing
        private int operationDuration; //Calculate
        private double rX; // Calculate
        private double width; // Calculate`
        private string color; // Calculate
        private int height =100; // Calculate
        private string timeDisplay; // Calculate
        private double timeRx; // Calculate
        private string patientCaseId; // Missing
        private PatientInfo patient;
        private string orName;

        public string ORName
        {
            get { return orName; }
            set { orName = value; }
        }


        public PatientInfo Patient
        {
            get { return patient; }
            set { patient = value; }
        }


        public string PatientCaseId
        {
            get { return patientCaseId; }
            set { patientCaseId = value; }
        }


        public double TimeRX
        {
            get { return timeRx; }
            set { timeRx = value; }
        }


        public string TimeDisplay
        {
            get { return timeDisplay; }
            set { timeDisplay = value; }
        }


        public int Height
        {
            get { return height; }
           
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }


        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public double RX
        {
            get { return rX; }
            set { rX = GetRelativeTime(); }
        }
        
        public int OperationDuration
        {
            get { return operationDuration= Helper.StringToIntTime(SchEndTime) - Helper.StringToIntTime(SchStartTime); }
            //set { operationDuration = StringToIntTime(SchEndTime) - StringToIntTime(SchStartTime); }
        }

        public int EndDelay
        {
            get { return endDelay; }
            set { endDelay = value; }
        }

        public int StartDelay
        {
            get { return startDelay; }
            set { startDelay = value; }
        }

        public string SchEndTime
        {
            get { return schEndTime; }
            set { schEndTime = value; }
        }
        
        public string SchStartTime
        {
            get { return schStartTime; }
            set { schStartTime = value; }
        }

        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }


        public string OpName
        {
            get { return opName; }
            set { opName = value; }
        }
        
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private double GetRelativeTime()
        {
            int displayTime = (_endDisplayTime - _stDisplayTime);
            int stPoint = Helper.StringToIntTime(SchStartTime) + startDelay;
            int endPoint = Helper.StringToIntTime(SchEndTime) + EndDelay;
            int timeFromStart = stPoint - _stDisplayTime;
            double position = Convert.ToDouble(timeFromStart * 100) / ( displayTime);
            this.Width = (Convert.ToDouble(endPoint - stPoint) / displayTime) * 100 ;

            // set display time
            string stDelay = (startDelay < 0) ? $"-{startDelay}" : $"+{startDelay}";
            string endDelay = (EndDelay < 0) ? $"-{EndDelay}" : $"+{EndDelay}";
            TimeDisplay = $"{schStartTime}({stDelay}) <{Helper.IntToString(OperationDuration)}> {SchEndTime}({endDelay})";

            // set color
            if (this.Status.ToLower() == "not admitted" || this.Status.ToLower() == "admitted")
            {
                Color = _Color1;
            }
            else if (this.Status.ToLower() == "in preop")
            {
                Color = _Color2;
            }
            else if(this.Status.ToLower() == "in or" || this.Status.ToLower() == "induction" || this.Status.ToLower() == "positioning" || this.Status.ToLower() == "procedure started" ||
                this.Status.ToLower() == "closing" || this.Status.ToLower() == "procedure ended" || this.Status.ToLower() == "emergence" || this.Status.ToLower() == "leave or" 
                || this.Status.ToLower() == "in room")
            {
                Color = _Color3;
            }
            else
            {
                Color = _Color4;
            }
            // set time position bar.
            TimeRX = Convert.ToDouble((_currentTime - _stDisplayTime) * 100) / (displayTime);

            return position;
        }

    }

    public enum OperationStatus
    {
        InPreOp,
        Admited,
        InOR,
        Positioning,
        LeaveOR,
        Emergency,
        NotAdmited,
        PreopPrep,
        Induction,
        ProcedureStatred,
        InPacu,
        LeftPacu,
        ICU,
        Closing
    }
}
