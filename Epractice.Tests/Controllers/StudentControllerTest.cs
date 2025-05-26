using Epractice.Controllers;
using Epractice.Models;
using Epractice.Services;
using Moq;
using Xunit;

namespace Epractice.Tests
{
    public class StudentControllerTest
    {
        [Fact]
        public void Student_withValidCIAndOver51Nota_HasApproved()
        {
            // Arrange
            var studentService = new Mock<IStudentService>();
            StudentController studentController = new StudentController(studentService.Object);

            studentService.Setup(s => s.HasApproved(1234567)).Returns(
                true
            );

            // Act
            Boolean result = studentController.EvaluateStudentHasApproved(1234567);

            // Assert
            Assert.True(result);


        }

        [Fact]
        public void Student_withValidCIButBelow51Nota_HasNotApproved()
        {
            // Arrange
            var studentService = new Mock<IStudentService>();
            var studentController = new StudentController(studentService.Object);

            studentService.Setup(s => s.HasApproved(2345678)).Returns(false);

            // Act
            bool result = studentController.EvaluateStudentHasApproved(2345678);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Student_withSpecificCI_ShouldReturnCorrectName()
        {
            // Arrange
            var student = new Student
            {
                CI = 1234567,
                Nombre = "Saul",
                Nota = 60
            };

            var mockService = new Mock<IStudentService>();
            mockService.Setup(s => s.GetById(1234567)).Returns(student);

            var controller = new StudentController(mockService.Object);

            // Act
            var nombre = controller.GetStudentName(1234567);

            // Assert
            Assert.Equal("Saul", nombre);
        } 

        [Fact]
        public void Student_withSpecificCI_ShouldReturnCorrectCI()
        {
            // Arrange
            var student = new Student
            {
                CI = 5554321,
                Nombre = "Ana",
                Nota = 80
            };

            var mockService = new Mock<IStudentService>();
            mockService.Setup(s => s.GetById(5554321)).Returns(student);

            var controller = new StudentController(mockService.Object);

            // Act
            var returnedStudent = mockService.Object.GetById(5554321);

            // Assert
            Assert.Equal(5554321, returnedStudent.CI);
        }
    
    }

}

