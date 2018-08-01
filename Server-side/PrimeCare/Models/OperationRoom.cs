using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeCare.Models
{
    public class OperationRoom
    {
        public string Name { get; set; }

        public string CurrentTime { get; set; }

        public List<Operation> Operations { get; set; }
    }
}