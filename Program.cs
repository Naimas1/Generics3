using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics3
{
    class CafeQueueApp
    {
        private Queue<string> queue = new Queue<string>();
        private Dictionary<string, bool> reservedTables = new Dictionary<string, bool>();

        public void AddToQueue(string visitorName)
        {
            queue.Enqueue(visitorName);
        }
        public void AddReservedVisitor(string visitorName, string tableNumber)
        {
            reservedTables[tableNumber] = true;
            queue.Enqueue(visitorName);
        }
        public bool IsTableAvailable(string tableNumber)
        {
            if (reservedTables.ContainsKey(tableNumber))
            {
                return !reservedTables[tableNumber];
            }
            else
            {
                return true;
            }
        }
        public void OccupyTable(string tableNumber)
        {
            if (queue.Count > 0)
            {
                string visitorName = queue.Dequeue();
                Console.WriteLine("Відвідувач {0} зайняв столик {1}", visitorName, tableNumber);

                if (reservedTables.ContainsKey(tableNumber))
                {
                    reservedTables[tableNumber] = false;
                }
            }
            else
            {
                Console.WriteLine("Немає відвідувачів у черзі.");
            }
        }
    }

    class Programrt
    {
        static void Main(string[] args)
        {
            CafeQueueApp app = new CafeQueueApp();

            app.AddToQueue("Visitor1");
            app.AddToQueue("Visitor2");

            app.AddReservedVisitor("Visitor3", "Table1");

            app.OccupyTable("Table2");
            app.OccupyTable("Table1");
            app.OccupyTable("Table3");
        }
    }
}
