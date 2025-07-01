// Enum for Course Categories
enum CourseCategory {
    FrontEnd = "Front-End",
    BackEnd = "Back-End",
    FullStack = "Full-Stack"
}

// Interface for Student
interface Student {
    name: string;
    age: number;
    courseName: string;
    knowsHTML: boolean;
}

// Class for Enrollment Logic
class CourseEnrollment {
    private category: CourseCategory;
    private isEligible: boolean;

    constructor(private student: Student) {}

    private determineCourseCategory(): void {
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
    }

    private checkEligibility(): void {
        const { age, courseName, knowsHTML } = this.student;
        this.isEligible =
            age >= 18 && (courseName !== "Angular" || knowsHTML);
    }

    printSummary(): void {
        this.determineCourseCategory();
        this.checkEligibility();

        console.log(`Student Name: ${this.student.name}`);
        console.log(`Age: ${this.student.age}`);
        console.log(`Course: ${this.student.courseName}`);
        console.log(`Knows HTML: ${this.student.knowsHTML}`);
        console.log(`Course Category: ${this.category}`);
        console.log(`Enrollment Status: ${this.isEligible ? "Eligible" : "Not Eligible"}`);
        console.log('------------------------');
    }
}


// Student Records
const students: Student[] = [
    { name: "Sneha", age: 20, courseName: "Angular", knowsHTML: true },
    { name: "Karan", age: 17, courseName: "Node.js", knowsHTML: false },
    { name: "Riya", age: 22, courseName: "Angular", knowsHTML: false },
    { name: "Aman", age: 25, courseName: "FullStack", knowsHTML: true }
];

// Loop through and print summaries
for (let student of students) {
    new CourseEnrollment(student).printSummary();
}