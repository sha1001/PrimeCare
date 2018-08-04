using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeCare.Models
{
    public class Operation
    {
        public string Id { get; set; }

        public string PatientCaseId { get; set; }

        public string Status { get; set; }

        public string OpName { get; set; }

        public string ImageName { get; set; }

        public string SchStartTime { get; set; }

        public string SchEndTime { get; set; }

        public int StartDelay { get; set; }

        public int EndDelay { get; set; }

        public int OperationDuration { get; set; }

        public decimal RX { get; set; }

        public decimal Width { get; set; }

        public PatientSummary Patient { get; set; }

        public string TimeRX { get; set; }

        public string TimeDisplay { get; set; }

        public string Height { get; set; }

        public string Color { get; set; }
    }
}