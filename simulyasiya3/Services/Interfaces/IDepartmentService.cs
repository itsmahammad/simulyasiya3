using simulyasiya3.ViewModels.DepartmentVMs;

namespace simulyasiya3.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentVM>> ShowAdminAsync();

        Task CreateAsync(DepartmentCreateUpdateVM vm);

        Task DeleteAsync(int id);

    }
}
