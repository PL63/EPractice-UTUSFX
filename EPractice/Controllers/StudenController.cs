using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

using EPractice.Models;
using EPractice.Services;

namespace EPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        
        private IStudentService _studentService;
       

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public List<Student> GetAll()
        {
            return _studentService.GetAll();
        }

        [HttpGet("{CI}")]
        public Student GetById(int CI)
        {
            return _studentService.GetById(CI);
        }

        [HttpGet("/Has-Approved/{CI}")]
        public Boolean EvaluateStudentHasApproved(int CI)
        {
            return _studentService.HasApproved(CI);
        }

        [HttpPost]
        public Student Create(Student student)
        {
            return _studentService.Create(student);
        }

        [HttpPut("{CI}")]
        public Student Update(int CI, Student updatedStudent)
        {
            return _studentService.Update(CI, updatedStudent);
        }

        [HttpDelete("{CI}")]
        public Student Delete(int CI)
        {
            return _studentService.Delete(CI);
        }
    }

}
