using simulyasiya3.ViewModels.ProjectVMs;
using System.Runtime.CompilerServices;

namespace simulyasiya3.Services.Interfaces
{
    public interface IProjectService
    {
        public Task<IEnumerable<ProjectUIVM>> ShowUIAsync();
        public Task<IEnumerable<ProjectVM>> ShowAdminAsync();

        public Task<ProjectCreateUpdateVM> GetCreateAsync();
        public Task CreateAsync(ProjectCreateUpdateVM vm);
    }
}
