using System.ComponentModel.DataAnnotations;

namespace simulyasiya3.ViewModels.DepartmentVMs
{
    public class DepartmentCreateUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
