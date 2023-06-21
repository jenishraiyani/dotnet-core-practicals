using Practical17.Models;

namespace Practical17.Interfaces
{
    public interface IStudentService
    {
        Students GetStudentById(int id);
        IEnumerable<Students> GetAllStudents();
      
        void AddStudent(Students student);
        void UpdateStudent(Students student);
        int DeleteStudent(int id);
    }
}
