// Enum for Department
var Department;
(function (Department) {
    Department["HR"] = "HR";
    Department["IT"] = "IT";
    Department["Sales"] = "Sales";
})(Department || (Department = {}));
// Enum for Salary Category
var SalaryCategory;
(function (SalaryCategory) {
    SalaryCategory["High"] = "High Earner";
    SalaryCategory["Mid"] = "Mid Earner";
    SalaryCategory["Low"] = "Low Earner";
})(SalaryCategory || (SalaryCategory = {}));
// Class to handle Salary Logic
var SalaryCalculator = /** @class */ (function () {
    function SalaryCalculator(employee) {
        this.employee = employee;
        console.log("Initialized for ".concat(employee.name));
    }
    SalaryCalculator.prototype.calculateBonus = function () {
        switch (this.employee.department) {
            case Department.HR: return this.employee.baseSalary * 0.10;
            case Department.IT: return this.employee.baseSalary * 0.15;
            case Department.Sales: return this.employee.baseSalary * 0.12;
            default: return 0;
        }
    };
    SalaryCalculator.prototype.categorizeEmployee = function () {
        if (this.netSalary >= 80000) {
            this.category = SalaryCategory.High;
        }
        else if (this.netSalary >= 50000) {
            this.category = SalaryCategory.Mid;
        }
        else {
            this.category = SalaryCategory.Low;
        }
    };
    SalaryCalculator.prototype.printEmployeeReport = function () {
        var bonus = this.calculateBonus();
        this.netSalary = this.employee.baseSalary + bonus;
        this.categorizeEmployee();
        console.log("Employee Name: ".concat(this.employee.name));
        console.log("Age: ".concat(this.employee.age));
        console.log("Department: ".concat(this.employee.department));
        console.log("Base Salary: \u20B9".concat(this.employee.baseSalary));
        console.log("Net Salary (with bonus): \u20B9".concat(this.netSalary));
        console.log("Category: ".concat(this.category));
        console.log('------------------------');
    };
    return SalaryCalculator;
}());
// Sample employees
var emp1 = {
    name: "Ravi",
    age: 28,
    department: Department.IT,
    baseSalary: 60000
};
var emp2 = {
    name: "Priya",
    age: 32,
    department: Department.HR,
    baseSalary: 48000
};
var emp3 = {
    name: "Arjun",
    age: 26,
    department: Department.Sales,
    baseSalary: 85000
};
// Instantiate and print reports
new SalaryCalculator(emp1).printEmployeeReport();
new SalaryCalculator(emp2).printEmployeeReport();
new SalaryCalculator(emp3).printEmployeeReport();
