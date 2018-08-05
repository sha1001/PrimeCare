using System.Collections.Generic;

namespace DataStructure
{
   public class Header
    {
        private string aic;
        private string nurseManager;
        private string pacuManager;
        private int orCount;
        private int orTotal;
        private int pacuCount;
        private int pacuTotal;
        private Dictionary<int,int> forecast =new Dictionary<int, int>();
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        public Dictionary<int,int> Forecast
        {
            get { return forecast; }
            set { forecast = value; }
        }

        public int PACUTotal
        {
            get { return pacuTotal; }
            set { pacuTotal = value; }
        }

        public int PACUCount
        {
            get { return pacuCount; }
            set { pacuCount = value; }
        }

        public int ORTotalCount
        {
            get { return orTotal; }
            set { orTotal = value; }
        }

        public int ORCount
        {
            get { return orCount; }
            set { orCount = value; }
        }

        public string PACUManager
        {
            get { return pacuManager; }
            set { pacuManager = value; }
        }

        public string NurseManager
        {
            get { return nurseManager; }
            set { nurseManager = value; }
        }


        public string AIC
        {
            get { return aic; }
            set { aic = value; }
        }

    }
}
