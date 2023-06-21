using Microsoft.EntityFrameworkCore;
using static NuGet.Packaging.PackagingConstants;

namespace Practical17.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {
        }
        public DbSet<Students> Students { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }

         

    }
}
