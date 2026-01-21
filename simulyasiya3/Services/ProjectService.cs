using Microsoft.EntityFrameworkCore;
using simulyasiya3.Data;
using simulyasiya3.Services.Interfaces;
using simulyasiya3.ViewModels.ProjectVMs;

namespace simulyasiya3.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectUIVM>> ShowUIAsync()
        {
            var projects = await _context.Projects.Select(p => new ProjectUIVM
            {
                Name = p.Name,
                Department = p.Department.Name,
                ImageUrl = p.ImageUrl
            }).ToListAsync();
            return projects;
        }
    }
}
