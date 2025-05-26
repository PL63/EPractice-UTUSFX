using System.Collections.Generic;
using System.Threading.Tasks;
using EPractice.Models;

namespace EPractice.Services
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student GetById(int CI);
        Student Create(Student student);
        Student Update(int CI, Student student);
        Student Delete(int CI);

        Boolean HasApproved(int CI);
    }
}
