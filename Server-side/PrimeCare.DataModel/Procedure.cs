using System;
using System.Collections.Generic;

namespace DataStructure
{
    public class Procedure
    {
        private Header header;
        private List<string> alert;

        

        private int stTime;
        private int endTime;
        private int hourCount;
        private List<OperationRoom> operationRooms =new List<OperationRoom>();
        private string currentTime;
        private List<string> list= new List<string>();
        private int _currentTime;
        private double timeRx;
        private int id;


        public List<string> Alert
        {
            get { return alert; }
            set { alert = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Procedure(string currentTime)
        {
            this._currentTime =Helper.StringToIntTime(currentTime);            
        }

        public void SetData(string currentTimeVal)
        {
            // set time position bar. Adding 5, to include the include the margin for the OR name. 
            timeRx = Convert.ToDouble((_currentTime - stTime) * 100) / (endTime + 150 - stTime) + 5;
            // set the date time string, based on the current time.
            currentTime = $"{currentTimeVal}:00";
            // set the time list.
            GetTimeList();
        }
        public double TimeRX
        {
            get { return timeRx; }
            //set { timeRx = value; }
        }
        public List<string> TimeList
        {
            get { return list; }
           // set { GetTimeList(); }
        }

        private void GetTimeList()
        {
            double st = stTime/60;
            double en = endTime / 60;
            int count = Convert.ToInt32(st);
            while (count <= en)
            {
                if(count < 10)
                {
                    list.Add($"0{count.ToString()}");
                }
                else
                {
                    list.Add(count.ToString());
                }
                
                count++;
            }
            hourCount =Convert.ToInt32(en - st);
        }
        public void AddOperationRoom(OperationRoom operationRoom)
        {
            operationRooms.Add(operationRoom);
        }
        public string CurrentTime
        {
            get { return currentTime; }
            //set { currentTime = value; }
        }

        public List<OperationRoom> OperationRooms
        {
            get { return operationRooms; }
            set { operationRooms = value; }
        }

        public int HourCount
        {
            get { return hourCount; }
            set { hourCount = value; }
        }

        public int EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        public int StartTime
        {
            get { return stTime; }
            set { stTime = value; }
        }

        public Header Header
        {
            get { return header; }
            set { header = value; }
        }
        
    }
}
