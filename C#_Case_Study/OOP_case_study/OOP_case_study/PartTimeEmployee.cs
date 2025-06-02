using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_case_study
{
    public class PartTimeEmployee : IPartTimeEmployee
    {
        public double Basic { get; set; }
        public double Da { get; set; }
        public double NetSalary { get; set; }

        public double CalculateSalary()
        {
            Da = Basic * 0.05;   // 5% of Basic
            NetSalary = Basic + Da;
            return NetSalary;
        }

        public string PrintEmployeeDetails(Employee employee)
        {
            return $"Employee Code: {employee.EmpCode}\n" +
                   $"Employee Name: {employee.EmpName}\n" +
                   $"Email: {employee.Email}\n" +
                   $"Department: {employee.DeptName}\n" +
                   $"Location: {employee.Location}\n" +
                   $"Basic Salary: {Basic}\n" +
                   $"DA: {Da}\n" +
                   $"Net Salary: {NetSalary}";
        }
    }
}
