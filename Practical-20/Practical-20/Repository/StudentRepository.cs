using Microsoft.EntityFrameworkCore;
using Practical_18.Models;
using Practical_20.Interfaces;
using Practical_20.Models;

namespace Practical_20.Repository
{
    public class StudentRepository : GenericRepository<Students>, IStudentRepository
    {
        private readonly AppDbContext _dbContext;

        public StudentRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Students> GetStudentById(int id)
        {
            return await _dbContext.Students.FindAsync(id);
           
        }
    }
}
