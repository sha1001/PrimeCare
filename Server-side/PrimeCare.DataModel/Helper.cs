using System;
using System.Linq;

namespace DataStructure
{
    public static class Helper
    {
        public static int DateTimeToIntTime(DateTime time)
        {
            if (time == null)
                return 0;
            string timeString = time.ToString("HH:mm");
            return StringToIntTime(timeString);
        }
        public static int StringToIntTime(string time)
        {
            if(string.IsNullOrEmpty(time) || string.IsNullOrWhiteSpace(time) || time == "")
            {
                return 0;
            }
            string[] st = time.Split(':');
            int hr, mn;
            if(st.Count() == 2)
            {
                int.TryParse(st[0], out hr);
                int.TryParse(st[1], out mn);
            }
            else
            // if the time format is 5(minute) or -5.
            {
                hr = 0;
                int.TryParse(st[0], out mn);
            }
            
            int itime = (hr * 60) + mn;
            return itime;
        }
        public static string IntToString(int time)
        {
            int hh = time / 60;
            double mm = Math.Round(Convert.ToDouble(time % 60), 4);
            if (mm < 9)
                return $"{hh.ToString()}:0{mm.ToString()}";

            return $"{hh.ToString()}:{mm.ToString()}";
        }
    }
}
