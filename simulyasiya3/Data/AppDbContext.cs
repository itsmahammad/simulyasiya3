using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using simulyasiya3.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace simulyasiya3.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
