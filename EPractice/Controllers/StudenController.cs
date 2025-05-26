using Microsoft.AspNetCore.Mvc;

namespace EPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudenController : ControllerBase
    {
        public class Student
        {
            public string CI { get; set; }
            public string Name { get; set; }
            public double Grade { get; set; }
            public bool IsApproved => Grade >= 51;
        }

        // Example in-memory data
        private static readonly List<Student> Students = new List<Student>
        {
            new Student { CI = "123456", Name = "Alice", Grade = 75 },
            new Student { CI = "654321", Name = "Bob", Grade = 45 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            return Ok(Students);
        }

        [HttpGet("{ci}")]
        public ActionResult<Student> GetByCI(string ci)
        {
            var student = Students.FirstOrDefault(s => s.CI == ci);
            if (student == null)
                return NotFound();
            return Ok(student);
        }
    }
}