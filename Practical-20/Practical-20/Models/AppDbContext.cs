﻿using Microsoft.EntityFrameworkCore;
using Practical_20.Models;
using System.Collections.Generic;

namespace Practical_18.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        public DbSet<Students> Students { get; set; }
    }
}
