using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_case_study
{
    public class FullTimeEmployee : IFullTimeEmployee
    {
        public double Basic { get; set; }
        public double Hra { get; set; }
        public double Da { get; set; }
        public double NetSalary { get; set; }

        public double CalculateSalary()
        {
            Hra = Basic * 0.15; // 15% of Basic
            Da = Basic * 0.10;   // 10% of Basic
            NetSalary = Basic + Hra + Da;
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
                   $"HRA: {Hra}\n" +
                   $"DA: {Da}\n" +
                   $"Net Salary: {NetSalary}";
        }
    }
}
