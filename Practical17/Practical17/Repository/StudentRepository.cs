using Microsoft.EntityFrameworkCore;
using Practical17.Interfaces;
using Practical17.Models;

namespace Practical17.Repository
{
    public class StudentRepository : IStudentService
    {
        private readonly AppDbContext _dbContext;

        public StudentRepository(AppDbContext context)
        {
            _dbContext =  context;
        }

        public Students GetStudentById(int id)
        {
            return _dbContext.Students.Find(id);
        }

        public IEnumerable<Students> GetAllStudents()
        {
            return _dbContext.Students.ToList();
        }

        public void AddStudent(Students student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        public void UpdateStudent(Students student)
        {
            _dbContext.Entry(student).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public int DeleteStudent(int id)
        {
            var student = _dbContext.Students.Find(id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                int count = _dbContext.SaveChanges();
                return count;
            }
            return 0;
        }
    }
}
