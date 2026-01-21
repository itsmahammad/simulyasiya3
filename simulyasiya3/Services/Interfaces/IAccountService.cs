using simulyasiya3.ViewModels.AccountVMs;

namespace simulyasiya3.Services.Interfaces
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterVM vm);
        Task LoginAsync(LoginVM vm);
        Task LogoutAsync();
    }
}
