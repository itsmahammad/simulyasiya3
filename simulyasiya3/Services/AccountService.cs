using Microsoft.AspNetCore.Identity;
using simulyasiya3.Models;
using simulyasiya3.Services.Interfaces;
using simulyasiya3.ViewModels.AccountVMs;

namespace simulyasiya3.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task LoginAsync(LoginVM vm)
        {
            var result =  await _signInManager.PasswordSignInAsync(
                        vm.UserName,
                        vm.Password,
                        isPersistent: false,
                        lockoutOnFailure: false
                );
            if (!result.Succeeded)
            {
                throw new Exception("login failed");
            }
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task RegisterAsync(RegisterVM vm)
        {
            var user = new AppUser
            {
                FullName = vm.FullName,
                UserName = vm.UserName,
                Email = vm.Email
            };
            var result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                throw new Exception("registration failed");
            }
            var totalUsers = _userManager.Users.Count();
            //rol teyin etmek ucun
            await _userManager.AddToRoleAsync(user, "User");
            
        }
    }
}
