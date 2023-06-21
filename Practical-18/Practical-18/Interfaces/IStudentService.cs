using Practical_18.Models;

namespace Practical_18.Interfaces
{
    public interface IStudentService
    {
        Task<Students> GetStudentById(int id);
        Task<List<Students>> GetAllStudents();
        Task<Students> AddStudent(Students student);
        Task<Students> UpdateStudent(Students student);
        Task<Students> DeleteStudent(int id);
    }
}
