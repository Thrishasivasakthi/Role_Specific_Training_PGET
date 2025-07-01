// Enum for Course Categories
var CourseCategory;
(function (CourseCategory) {
    CourseCategory["FrontEnd"] = "Front-End";
    CourseCategory["BackEnd"] = "Back-End";
    CourseCategory["FullStack"] = "Full-Stack";
})(CourseCategory || (CourseCategory = {}));
// Class for Enrollment Logic
var CourseEnrollment = /** @class */ (function () {
    function CourseEnrollment(student) {
        this.student = student;
    }
    CourseEnrollment.prototype.determineCourseCategory = function () {
        switch (this.student.courseName) {
            case "Angular":
                this.category = CourseCategory.FrontEnd;
                break;
            case "Node.js":
                this.category = CourseCategory.BackEnd;
                break;
            case "FullStack":
                this.category = CourseCategory.FullStack;
                break;
            default:
                throw new Error("Unknown course");
        }
    };
    CourseEnrollment.prototype.checkEligibility = function () {
        var _a = this.student, age = _a.age, courseName = _a.courseName, knowsHTML = _a.knowsHTML;
        this.isEligible =
            age >= 18 && (courseName !== "Angular" || knowsHTML);
    };
    CourseEnrollment.prototype.printSummary = function () {
        this.determineCourseCategory();
        this.checkEligibility();
        console.log("Student Name: ".concat(this.student.name));
        console.log("Age: ".concat(this.student.age));
        console.log("Course: ".concat(this.student.courseName));
        console.log("Knows HTML: ".concat(this.student.knowsHTML));
        console.log("Course Category: ".concat(this.category));
        console.log("Enrollment Status: ".concat(this.isEligible ? "Eligible" : "Not Eligible"));
        console.log('------------------------');
    };
    return CourseEnrollment;
}());
// Student Records
var students = [
    { name: "Sneha", age: 20, courseName: "Angular", knowsHTML: true },
    { name: "Karan", age: 17, courseName: "Node.js", knowsHTML: false },
    { name: "Riya", age: 22, courseName: "Angular", knowsHTML: false },
    { name: "Aman", age: 25, courseName: "FullStack", knowsHTML: true }
];
// Loop through and print summaries
for (var _i = 0, students_1 = students; _i < students_1.length; _i++) {
    var student = students_1[_i];
    new CourseEnrollment(student).printSummary();
}
