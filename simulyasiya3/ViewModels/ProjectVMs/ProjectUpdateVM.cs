using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace simulyasiya3.ViewModels.ProjectVMs
{
    public class ProjectUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public IFormFile? Image { get; set; }
        public string? CurrentImageUrl { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; } = new List<SelectListItem>();
    }
}
