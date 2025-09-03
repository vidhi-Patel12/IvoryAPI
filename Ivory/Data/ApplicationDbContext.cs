using Ivory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Collections.Generic;

namespace Ivory.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Register> Register { get; set; }

        public DbSet<Login> Login { get; set; }

        public DbSet<Service> Services { get; set; }
        public DbSet<SubService> SubServices { get; set; }

    }
}
