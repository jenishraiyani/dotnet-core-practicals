using Practical_20.Models;

namespace Practical_20.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Students>> GetAll();
        Task AddStudent(Students student);
    }
}
