using simulyasiya3.ViewModels.ProjectVMs;

namespace simulyasiya3.Services.Interfaces
{
    public interface IProjectService
    {
        public Task<IEnumerable<ProjectUIVM>> ShowUIAsync();
    }
}
