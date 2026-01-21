using System.ComponentModel.DataAnnotations;

namespace simulyasiya3.ViewModels.AccountVMs
{
    public class RegisterVM
    {
        [Required]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, Compare("Password"), MinLength(8)]
        public string ConfirmPassword { get; set; }

    }
}
