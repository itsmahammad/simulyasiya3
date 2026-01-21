using Microsoft.EntityFrameworkCore;

namespace simulyasiya3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
