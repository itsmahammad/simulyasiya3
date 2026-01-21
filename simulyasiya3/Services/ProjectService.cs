using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using simulyasiya3.Data;
using simulyasiya3.Helpers;
using simulyasiya3.Models;
using simulyasiya3.Services.Interfaces;
using simulyasiya3.ViewModels.ProjectVMs;

namespace simulyasiya3.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _context;
        private readonly IFileHelper _helper;

        public ProjectService(AppDbContext context, IFileHelper helper)
        {
            _context = context;
            _helper = helper;
        }

        public async Task CreateAsync(ProjectCreateVM vm)
        {
            string imagePath = null;
            if (vm.Image != null)
            {
                string name = _helper.UniqueName(vm.Image.FileName);
                string path = _helper.GeneratePath("assets/images", name);
                await _helper.UploadAsync(vm.Image, path);
                imagePath = "/assets/images/" + name;
            }
            
            var Project = new Project()
            {
                Name = vm.Name,
                DepartmentId = vm.DepartmentId,
                ImageUrl = imagePath
            };

            await _context.Projects.AddAsync(Project);
            await _context.SaveChangesAsync();
        }

        public async Task<ProjectCreateVM> GetCreateAsync()
        {
            var vm = new ProjectCreateVM
            {
                Departments = await _context.Departments.Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }).ToListAsync()
            };
            return vm;
        }


        public async Task<IEnumerable<ProjectVM>> ShowAdminAsync()
        {
            var projects = await _context.Projects.Select(p => new ProjectVM
            {
                Id = p.Id,
                Name = p.Name,
                Department = p.Department.Name,
                Created = p.Created,
                ImageUrl = p.ImageUrl,
            }).ToListAsync();
            return projects;
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

        public async Task<ProjectUpdateVM> GetUpdateAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return null!;
            }
            var vm = new ProjectUpdateVM
            {
                Id = project.Id,
                Name = project.Name,
                DepartmentId = project.DepartmentId,
                CurrentImageUrl = project.ImageUrl,
                Departments = await _context.Departments.Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }).ToListAsync()
            };
            return vm;
        }
        public async Task UpdateAsync(ProjectUpdateVM vm)
        {
            var project = await _context.Projects.FindAsync(vm.Id);
            if (project == null)
                throw new Exception("Project not found");
            project.Name = vm.Name;
            project.DepartmentId = vm.DepartmentId;
            if (vm.Image != null)
            {
                var name = _helper.UniqueName(vm.Image.FileName);
                var path = _helper.GeneratePath("assets/images", name);
                await _helper.UploadAsync(vm.Image, path);
                project.ImageUrl = "/assets/images/" + name;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if(project != null)
            {
                _context.Remove(project);
                await _context.SaveChangesAsync();
            }
        }
    }
}
