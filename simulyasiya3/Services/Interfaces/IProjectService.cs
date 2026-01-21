using simulyasiya3.ViewModels.ProjectVMs;
using System.Runtime.CompilerServices;

namespace simulyasiya3.Services.Interfaces
{
    public interface IProjectService
    {
        public Task<IEnumerable<ProjectUIVM>> ShowUIAsync();
        public Task<IEnumerable<ProjectVM>> ShowAdminAsync();

        public Task<ProjectCreateVM> GetCreateAsync();
        public Task CreateAsync(ProjectCreateVM vm);

        public Task<ProjectUpdateVM> GetUpdateAsync(int id);
        public Task UpdateAsync(ProjectUpdateVM vm);

        public Task DeleteAsync(int id);
    }
}
