using Practical_20.Models;

namespace Practical_20.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Students>
    {
        Task<Students> GetStudentById(int studentId);
    }
}
