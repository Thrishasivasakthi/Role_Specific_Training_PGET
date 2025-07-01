// Enum for Department
enum Department {
    HR = "HR",
    IT = "IT",
    Sales = "Sales"
}

// Enum for Salary Category
enum SalaryCategory {
    High = "High Earner",
    Mid = "Mid Earner",
    Low = "Low Earner"
}

// Interface for Employee Model
interface Employee {
    name: string;
    age: number;
    department: Department;
    baseSalary: number;
}

// Class to handle Salary Logic
class SalaryCalculator {
    private category: SalaryCategory;
    private netSalary: number;

    constructor(private employee: Employee) {
        console.log(`Initialized for ${employee.name}`);

    }

    private calculateBonus(): number {
        switch (this.employee.department) {
            case Department.HR: return this.employee.baseSalary * 0.10;
            case Department.IT: return this.employee.baseSalary * 0.15;
            case Department.Sales: return this.employee.baseSalary * 0.12;
            default: return 0;
        }
    }

    private categorizeEmployee(): void {
        if (this.netSalary >= 80000) {
            this.category = SalaryCategory.High;
        } else if (this.netSalary >= 50000) {
            this.category = SalaryCategory.Mid;
        } else {
            this.category = SalaryCategory.Low;
        }
    }

    printEmployeeReport(): void {
        const bonus = this.calculateBonus();
        this.netSalary = this.employee.baseSalary + bonus;
        this.categorizeEmployee();

        console.log(`Employee Name: ${this.employee.name}`);
        console.log(`Age: ${this.employee.age}`);
        console.log(`Department: ${this.employee.department}`);
        console.log(`Base Salary: ₹${this.employee.baseSalary}`);
        console.log(`Net Salary (with bonus): ₹${this.netSalary}`);
        console.log(`Category: ${this.category}`);
        console.log('------------------------');
    }
}

// Sample employees
let emp1: Employee = {
    name: "Ravi",
    age: 28,
    department: Department.IT,
    baseSalary: 60000
};

let emp2: Employee = {
    name: "Priya",
    age: 32,
    department: Department.HR,
    baseSalary: 48000
};

let emp3: Employee = {
    name: "Arjun",
    age: 26,
    department: Department.Sales,
    baseSalary: 85000
};

// Instantiate and print reports
new SalaryCalculator(emp1).printEmployeeReport();
new SalaryCalculator(emp2).printEmployeeReport();
new SalaryCalculator(emp3).printEmployeeReport();