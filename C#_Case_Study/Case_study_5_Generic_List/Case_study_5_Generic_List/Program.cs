using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Program
{
    static List<Student> students = new List<Student>();

    static void Main(string[] args)
    {
        // Initialize with some sample students
        students.Add(new Student { Id = 1, Name = "Alice" });
        students.Add(new Student { Id = 2, Name = "Bob" });
        students.Add(new Student { Id = 3, Name = "Charlie" });

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nStudent Management System");
            Console.WriteLine("1. Add a student");
            Console.WriteLine("2. Display all students");
            Console.WriteLine("3. Search for a student by name");
            Console.WriteLine("4. Remove a student by name");
            Console.WriteLine("5. Count total students");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        DisplayAllStudents();
                        break;
                    case 3:
                        SearchStudent();
                        break;
                    case 4:
                        RemoveStudent();
                        break;
                    case 5:
                        CountStudents();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter student ID: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                students.Add(new Student { Id = id, Name = name });
                Console.WriteLine("Student added successfully.");
            }
            else
            {
                Console.WriteLine("Name cannot be empty.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID. Please enter a number.");
        }
    }

    static void DisplayAllStudents()
    {
        Console.WriteLine("\nAll Students:");
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
        }
        else
        {
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
            }
        }
    }

    static void SearchStudent()
    {
        Console.Write("Enter name to search: ");
        string searchName = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(searchName))
        {
            // Case-insensitive search
            var foundStudents = students.Where(s =>
                s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase)).ToList();

            if (foundStudents.Count > 0)
            {
                Console.WriteLine("Found student(s):");
                foreach (var student in foundStudents)
                {
                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
                }
            }
            else
            {
                Console.WriteLine("No student found with that name.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid name.");
        }
    }

    static void RemoveStudent()
    {
        Console.Write("Enter name to remove: ");
        string removeName = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(removeName))
        {
            // Case-insensitive search and remove
            int removedCount = students.RemoveAll(s =>
                s.Name.Equals(removeName, StringComparison.OrdinalIgnoreCase));

            if (removedCount > 0)
            {
                Console.WriteLine($"{removedCount} student(s) removed.");
                DisplayAllStudents();
            }
            else
            {
                Console.WriteLine("No student found with that name.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid name.");
        }
    }

    static void CountStudents()
    {
        Console.WriteLine($"Total number of students: {students.Count}");
    }
}