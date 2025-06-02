using OOP_case_study;

class Program
{
    static void Main(string[] args)
    {
        // Step 7a: Create object of Employee class with default values
        Employee emp = new Employee
        {
            EmpCode = 1001,
            EmpName = "John Doe",
            Email = "john.doe@abctech.com",
            DeptName = "Development",
            Location = "New York"
        };

        // Step 7b: Create PartTimeEmployee object and call methods
        Console.WriteLine("Part Time Employee Details:");
        Console.WriteLine("--------------------------");

        IPartTimeEmployee partTimeEmp = new PartTimeEmployee
        {
            Basic = 5000
        };
        partTimeEmp.CalculateSalary();
        Console.WriteLine(partTimeEmp.PrintEmployeeDetails(emp));

        Console.WriteLine("\n");

        // Step 7c: Create FullTimeEmployee object and call methods
        Console.WriteLine("Full Time Employee Details:");
        Console.WriteLine("--------------------------");

        IFullTimeEmployee fullTimeEmp = new FullTimeEmployee
        {
            Basic = 10000
        };
        fullTimeEmp.CalculateSalary();
        Console.WriteLine(fullTimeEmp.PrintEmployeeDetails(emp));
    }
}