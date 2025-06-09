using StudentDAL_1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDAL_1.Repository
{
    public class InMemoryStudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new List<Student>();
        
        public List<Student> GetAll()
        {
            return _students;
        }

        public Student GetByRollNo(int rollNo)
        {
            return _students.FirstOrDefault(s => s.RollNo == rollNo);
        }

        public Student GetByName(string name)
        {
            return _students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(Student student)
        {
            if (_students.Any(s => s.RollNo == student.RollNo))
            {
                throw new InvalidOperationException("Student with this roll number already exists.");
            }
            _students.Add(student);
        }

        public void Update(Student student)
        {
            var existingStudent = GetByRollNo(student.RollNo);
            if (existingStudent == null)
            {
                throw new InvalidOperationException("Student not found.");
            }
            existingStudent.Name = student.Name;
            existingStudent.Email = student.Email;
        }

        public void Delete(int rollNo)
        {
            var student = GetByRollNo(rollNo);
            if (student == null)
            {
                throw new InvalidOperationException("Student not found.");
            }
            _students.Remove(student);
        }
    }

}
