using Microsoft.AspNetCore.Identity;

namespace simulyasiya3.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = null!;
    }
}
