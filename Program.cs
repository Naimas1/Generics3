using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics3
{
    internal class EmployeeManagementApp
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(string fullName, string position, decimal salary, string email)
        {
            Employee employee = new Employee(fullName, position, salary, email);
            employees.Add(employee);
        }
        public void RemoveEmployee(string email)
        {
            Employee employee = FindEmployeeByEmail(email);
            if (employee != null)
            {
                employees.Remove(employee);
            }
            else
            {
                Console.WriteLine("Співробітник з таким email не знайдений.");
            }
        }
        public Employee FindEmployeeByEmail(string email)
        {
            foreach (Employee employee in employees)
            {
                if (employee.Email == email)
                {
                    return employee;
                }
            }
            return null;
        }
        public void UpdateEmployee(string email, string newFullName, string newPosition, decimal newSalary)
        {
            Employee employee = FindEmployeeByEmail(email);
            if (employee != null)
            {
                employee.FullName = newFullName;
                employee.Position = newPosition;
                employee.Salary = newSalary;
            }
            else
            {
                Console.WriteLine("Співробітник з таким email не знайдений.");
            }
        }
        public void PrintEmployees()
        {
            Console.WriteLine("Список співробітників:");
            foreach (Employee employee in employees)
            {
                Console.WriteLine("П.І.Б.: {0}", employee.FullName);
                Console.WriteLine("Посада: {0}", employee.Position);
                Console.WriteLine("Заробітна плата: {0}", employee.Salary);
                Console.WriteLine("Email: {0}", employee.Email);
                Console.WriteLine();
            }
        }
    }

    class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }

        public Employee(string fullName, string position, decimal salary, string email)
        {
            FullName = fullName;
            Position = position;
            Salary = salary;
            Email = email;
        }
    }

    class Programn
    {
        static void Main(string[] args)
        {
            EmployeeManagementApp app = new EmployeeManagementApp();

            app.AddEmployee("John Doe", "Manager", 5000, "john.doe@example.com");
            app.AddEmployee("Jane Smith", "Developer", 4000, "jane.smith@example.com");
            app.AddEmployee("Alex Johnson", "Designer", 4500, "alex.johnson@example.com");

            app.PrintEmployees();

            app.UpdateEmployee("jane.smith@example.com", "Jane Anderson", "Senior Developer", 5000);

            app.PrintEmployees();

            app.RemoveEmployee("alex.johnson@example.com");

            app.PrintEmployees();
        }
    }
}
