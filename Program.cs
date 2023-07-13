using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics3
{
    class ClinicQueueApp
    {
        private PriorityQueue<Patient> queue = new PriorityQueue<Patient>();

        public void AddPatient(string name, int priority)
        {
            Patient patient = new Patient(name, priority);
            queue.Enqueue(patient, patient.Priority);
        }
        public void ProcessNextPatient()
        {
            if (queue.Count > 0)
            {
                Patient nextPatient = queue.Dequeue();
                Console.WriteLine("Пацієнт {0} прийнятий до лікаря.", nextPatient.Name);
            }
            else
            {
                Console.WriteLine("Черга порожня.");
            }
        }
        public void PrintQueue()
        {
            Console.WriteLine("Список пацієнтів у черзі:");
            foreach (Patient patient in queue)
            {
                Console.WriteLine("Пацієнт: {0}, Пріоритет: {1}", patient.Name, patient.Priority);
            }
        }
    }

    class Patient : IComparable<Patient>
    {
        public string Name { get; set; }
        public int Priority { get; set; }

        public Patient(string name, int priority)
        {
            Name = name;
            Priority = priority;
        }

        public int CompareTo(Patient other)
        {
            return other.Priority.CompareTo(Priority);
        }
    }

    class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> data;

        public int Count
        {
            get { return data.Count; }
        }

        public PriorityQueue()
        {
            data = new List<T>();
        }

        public void Enqueue(T item, int priority)
        {
            item.Priority = priority;
            data.Add(item);
            data.Sort();
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Черга порожня.");
            }

            T item = data[0];
            data.RemoveAt(0);
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }

    class Programtr
    {
        static void Main(string[] args)
        {
            ClinicQueueApp app = new ClinicQueueApp();

            app.AddPatient("Пацієнт 1", 3);
            app.AddPatient("Пацієнт 2", 1);
            app.AddPatient("Пацієнт 3", 2);

            app.PrintQueue();

            app.AddPatient("Пацієнт 4", 4);

            app.PrintQueue();

            app.ProcessNextPatient();
            app.ProcessNextPatient();
            app.ProcessNextPatient();
            app.ProcessNextPatient();

            app.PrintQueue();
        }
    }
}
