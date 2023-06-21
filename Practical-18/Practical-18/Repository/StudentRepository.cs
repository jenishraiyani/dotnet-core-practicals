using Microsoft.EntityFrameworkCore;
using Practical_18.Interfaces;
using Practical_18.Models;

namespace Practical_18.Repository
{ 
    namespace Practical17.Repository
    {
        public class StudentRepository : IStudentService
        {
            private readonly AppDbContext _dbContext;

            public StudentRepository(AppDbContext context)
            {
                _dbContext = context;
            }

            public async Task<Students> GetStudentById(int id)
            {
                return await _dbContext.Students.FindAsync(id);
            }

            public async Task<List<Students>> GetAllStudents()
            {
                return await _dbContext.Students.ToListAsync();
            }

            public async Task<Students> AddStudent(Students student)
            {
                _dbContext.Students.Add(student);
                await _dbContext.SaveChangesAsync();
                return student;
            }

            public async Task<Students> UpdateStudent(Students student)
            {
                var studentData = await _dbContext.Students.FindAsync(student.StudentId);
                if (studentData == null)
                {
                    return null;
                }

                studentData.StudentName = student.StudentName;
                studentData.Email = student.Email;
                studentData.Phone = student.Phone;
             
                await _dbContext.SaveChangesAsync();
               
                return student;
            }

            public async Task<Students> DeleteStudent(int id)
            {
                var studentData = await _dbContext.Students.FindAsync(id);
                if (studentData == null)
                {
                    return null;
                }

                _dbContext.Students.Remove(studentData);
                await _dbContext.SaveChangesAsync();
                return studentData;
                 

            }
        }
    }

}
