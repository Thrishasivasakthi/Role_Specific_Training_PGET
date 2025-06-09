using StudentDAL_1.Repository;
using StudentDAL_1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDAL_1.BusinessLogic
{
    public class StudentService
    {
        private readonly IStudentRepository _repository;
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public List<Student> GetAllStudents()
        {
            return _repository.GetAll();
        }

        public Student GetStudentByRollNo(int rollNo)
        {
            return _repository.GetByRollNo(rollNo);
        }

        public Student GetStudentByName(string name)
        {
            return _repository.GetByName(name);
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");
            }
            _repository.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");
            }
            _repository.Update(student);
        }

        public void RemoveStudent(int rollNo)
        {
            var student = _repository.GetByRollNo(rollNo);
            if (student != null) {
                throw new InvalidOperationException("Student not found.");
            }
            _repository.Delete(rollNo);
            
        }
        
    }

}
