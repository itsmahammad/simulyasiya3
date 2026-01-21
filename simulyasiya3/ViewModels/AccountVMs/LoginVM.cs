using System.ComponentModel.DataAnnotations;

namespace simulyasiya3.ViewModels.AccountVMs
{
    public class LoginVM
    {
        [Required]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
