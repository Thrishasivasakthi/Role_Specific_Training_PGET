using Moq;
using StudentDAL_1.BusinessLogic;
using StudentDAL_1.Domain;
using StudentDAL_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTest
{
    [TestFixture]
    public class StudentServiceTest
    {
        private Mock<IStudentRepository> _mockRepo;
        private StudentService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IStudentRepository>();
            _service = new StudentService(_mockRepo.Object);
        }

        [Test]
        public void GetStudents()
        {
            var students = new List<Student>
            {
                new Student { RollNo = 1, Name = "John" },
                new Student { RollNo = 2, Name = "Alice" }
            };

            _mockRepo.Setup(r => r.GetAll()).Returns(students);

            var result = _service.GetAllStudents();

            Assert.AreEqual(2, result.Count);
            _mockRepo.Verify(r => r.GetAll(), Times.Once);
        }

        [Test]
        public void GetStudentByRollNo_ShouldReturnStudent()
        {
            var expected = new Student { RollNo = 2, Name = "Alice", Email = "abc@gmail.com" };
            _mockRepo.Setup(r => r.GetByRollNo(2)).Returns(expected);

            var result = _service.GetStudentByRollNo(2);

            Assert.IsNotNull(result);
            Assert.AreEqual("Alice", result.Name);
            _mockRepo.Verify(r => r.GetByRollNo(2), Times.Once);
        }

        [Test]
        public void GetStudentByName_ShouldReturnStudent()
        {
            var expected = new Student { RollNo = 3, Name = "Thrisha", Email = "acg@gmail.com" };
            _mockRepo.Setup(r => r.GetByName("Thrisha")).Returns(expected);

            var result = _service.GetStudentByName("Thrisha");

            Assert.IsNotNull(result);
            Assert.AreEqual("Thrisha", result.Name);
            _mockRepo.Verify(r => r.GetByName("Thrisha"), Times.Once);
        }

        [Test]
        public void AddStudent_ShouldInvokeAdd()
        {
            var student = new Student { RollNo = 1, Name = "John", Email = "john@example.com" };

            _service.AddStudent(student);

            _mockRepo.Verify(r => r.Add(It.Is<Student>(s => s.Name == "John")), Times.Once);
        }

        [Test]
        [TestCase(1)]
        public void RemoveStudent_ShouldInvokeRemove(int id)
        {

            _service.RemoveStudent(id);

            // Assert
            _mockRepo.Verify(r => r.Delete(id), Times.Once);
        }
        [Test]
        public void UpdateStudent_ShouldCallUpdateWithCorrectData()
        {
            // Arrange
            var updatedStudent = new Student
            {
                RollNo = 10,
                Name = "Updated Name",
                Email = "updated@example.com"
            };

            // Act
            _service.UpdateStudent(updatedStudent);

            // Assert
            _mockRepo.Verify(
                r => r.Update(It.Is<Student>(s =>
                    s.RollNo == 10 &&
                    s.Name == "Updated Name" &&
                    s.Email == "updated@example.com"
                )), Times.Once);
        }

    }
}
