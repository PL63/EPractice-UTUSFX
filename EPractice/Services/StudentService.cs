using EPractice.Models;

namespace EPractice.Services
{
    public class StudentService: IStudentService
    {
        // In-memory list for demonstration purposes
        private List<Student> _students;
       
        public StudentService()
        {
            _students = new List<Student>
            {
                new Student { CI = 1234567, Nombre = "Saul", Nota = 52 },
                new Student { CI = 2345678, Nombre = "Jorge", Nota = 45 },
                new Student { CI = 3456789, Nombre = "Ana", Nota = 78 }
            };
        }


        public List<Student> GetAll()
        {
            return _students;
        }


        public Student GetById(int CI)
        {
            Student student = _students.FirstOrDefault(s => s.CI == CI);
            return student;
        }


        public Student Create(Student student)
        {
            student.CI = _students.Any() ? _students.Max(s => s.CI) + 1 : 1;
            _students.Add(student);
            return student;
        }


        public Student Update(int CI, Student updatedStudent)
        {
            var student = _students.FirstOrDefault(s => s.CI == CI);
            if (student == null)
                return null;

            student.Nombre = updatedStudent.Nombre;
            student.Nota = updatedStudent.Nota;
            return student;
        }


        public Student Delete(int CI)
        {
            var student = _students.FirstOrDefault(s => s.CI == CI);
            if (student == null)
                return null;

            _students.Remove(student);
            return student;
        }
            
        public Boolean HasApproved(int CI)
        {
            var student = _students.FirstOrDefault(s => s.CI == CI);
            if (student == null)
                return false;

            return student.Nota >= 51;
        }

    }

}
    
    
