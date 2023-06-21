using Microsoft.EntityFrameworkCore;
using Practical17.Interfaces;
using Practical17.Models;

namespace Practical17.Repository
{
    public class RoleRepository : IRoleService
    {
        private readonly AppDbContext _dbContext;

        public RoleRepository(AppDbContext context)
        {
            _dbContext = context;
        }
        public Roles GetRoleById(int id)
        {
            return _dbContext.Roles.Find(id);
        }
    }
}
