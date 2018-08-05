using System.Collections.Generic;

namespace DataStructure
{
   public class OperationRoom
    {
        private int id;
        private string name;
        private List<Operation> list = new List<Operation>();

        public List<Operation> Operations
        {
            get { return list; }
            set { list = value; }
        }
        public void Add(Operation op)
        {
            list.Add(op);
        }

        public void Add(IEnumerable<Operation> ops)
        {
            list.AddRange(ops);
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

    }
}
