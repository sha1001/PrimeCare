using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeCare.Models
{
    public class Procedure
    {
        public List<string> TimeList { get; set; }

        public string CurrentTime { get; set; }

        public int Id { get; set; }

        public List<string> Alert { get; set; }

        public List<OperationRoom> OperationRooms { get; set; }

        public decimal TimeRX { get; set; }

    }
}