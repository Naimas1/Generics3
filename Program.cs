using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics3
{
    class EmployeeManagementApp
    {
        private Dictionary<string, string> employeeCredentials = new Dictionary<string, string>();
        public void AddEmployee(string login, string password)
        {
            employeeCredentials[login] = password;
        }
        public void RemoveEmployee(string login)
        {
            employeeCredentials.Remove(login);
        }
        public void UpdateEmployee(string login, string newPassword)
        {
            if (employeeCredentials.ContainsKey(login))
            {
                employeeCredentials[login] = newPassword;
            }
            else
            {
                Console.WriteLine("Співробітник з таким логіном не існує.");
            }
        }
        public string GetPassword(string login)
        {
            if (employeeCredentials.ContainsKey(login))
            {
                return employeeCredentials[login];
            }
            else
            {
                return null;
            }
        }
    }

    class Programr
    {
        static void Main(string[] args)
        {
            EmployeeManagementApp app = new EmployeeManagementApp();

            app.AddEmployee("john", "pass123");
            app.AddEmployee("jane", "pass456");
            app.AddEmployee("alex", "pass789");

            string password = app.GetPassword("john");
            if (password != null)
            {
                Console.WriteLine("Пароль співробітника з логіном 'john': " + password);
            }
            else
            {
                Console.WriteLine("Співробітник з логіном 'john' не знайдений.");
            }
            app.UpdateEmployee("jane", "newpass456");

            app.RemoveEmployee("alex");
        }
    }
}
