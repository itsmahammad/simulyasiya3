using Microsoft.AspNetCore.Mvc.Rendering;
using simulyasiya3.Models;
using System.ComponentModel.DataAnnotations;

namespace simulyasiya3.ViewModels.ProjectVMs
{
    public class ProjectCreateUpdateVM
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        public int DepartmentId { get; set; }
        public IEnumerable<SelectListItem>? Departments { get; set; }
    }
}
