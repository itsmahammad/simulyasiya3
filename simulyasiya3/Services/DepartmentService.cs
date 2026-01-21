using Microsoft.EntityFrameworkCore;
using simulyasiya3.Data;
using simulyasiya3.Models;
using simulyasiya3.Services.Interfaces;
using simulyasiya3.ViewModels.DepartmentVMs;

namespace simulyasiya3.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(DepartmentCreateUpdateVM vm)
        {
            var department = new Department()
            {

                Name = vm.Name,
            };
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<DepartmentVM>> ShowAdminAsync()
        {
            var departments = await _context.Departments.Select(d => new DepartmentVM
            {
                Id = d.Id,
                Name = d.Name,
                Created = d.Created,
                Projects = d.Projects.Count()
            }).ToListAsync();
            return departments;
        }

        public async Task<DepartmentCreateUpdateVM> GetUpdateAsync(int id)
        {
            var vm = await _context.Departments.FindAsync(id);
            return new DepartmentCreateUpdateVM
            {
                Id = vm.Id,
                Name = vm.Name
            };
        }

        public async Task UpdateAsync(DepartmentCreateUpdateVM vm)
        {
            var department = await _context.Departments.FindAsync(vm.Id);
            department.Name = vm.Name;
            await _context.SaveChangesAsync();
        }
    }
}
