using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics3
{
    public class EmployeeManagementApp
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
        public List<Employee> SearchEmployees(string keyword)
        {
            List<Employee> searchResults = new List<Employee>();

            foreach (Employee employee in employees)
            {
                if (employee.FullName.Contains(keyword) ||
                    employee.Position.Contains(keyword) ||
                    employee.Email.Contains(keyword))
                {
                    searchResults.Add(employee);
                }
            }

            return searchResults;
        }
        public void SortEmployees(string sortBy)
        {
            switch (sortBy)
            {
                case "fullName":
                    employees.Sort((emp1, emp2) => emp1.FullName.CompareTo(emp2.FullName));
                    break;
                case "position":
                    employees.Sort((emp1, emp2) => emp1.Position.CompareTo(emp2.Position));
                    break;
                case "salary":
                    employees.Sort((emp1, emp2) => emp1.Salary.CompareTo(emp2.Salary));
                    break;
                case "email":
                    employees.Sort((emp1, emp2) => emp1.Email.CompareTo(emp2.Email));
                    break;
                default:
                    Console.WriteLine("Невірний параметр сортування.");
                    break;
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
        private Employee FindEmployeeByEmail(string email)
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

    class Programy
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

            List<Employee> searchResults = app.SearchEmployees("John");
            Console.WriteLine("Результати пошуку за ключовим словом 'John':");
            foreach (Employee employee in searchResults)
            {
                Console.WriteLine(employee.FullName);
            }

            app.SortEmployees("salary");
            Console.WriteLine("Сортування за заробітною платою:");
            app.PrintEmployees();
        }
    }
}
