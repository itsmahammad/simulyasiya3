using Microsoft.EntityFrameworkCore;
using simulyasiya3.Models;

namespace simulyasiya3.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
