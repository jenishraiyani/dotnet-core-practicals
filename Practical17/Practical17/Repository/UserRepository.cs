using Microsoft.EntityFrameworkCore;
using Practical17.Interfaces;
using Practical17.Models;

namespace Practical17.Repository
{
    public class UserRepository : IUserService
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext context)
        {
            _dbContext = context;
        }
        public Users GetUserById(int id)
        {
            return _dbContext.Users.Find(id);
        }
        public IEnumerable<Users> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }
        public void AddUser(Users users)
        {
            _dbContext.Users.Add(users);
            _dbContext.SaveChanges();
        }
    }
}
