using Microsoft.AspNetCore.Mvc;
using simulyasiya3.Services.Interfaces;
using simulyasiya3.ViewModels.ProjectVMs;

namespace simulyasiya3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _service.ShowAdminAsync();
            return View(projects);
        }

        public async Task<IActionResult> Create()
        {
            var vm = await _service.GetCreateAsync();
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProjectCreateUpdateVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Departments = (await _service.GetCreateAsync()).Departments;
                return View(vm);
            }
            await _service.CreateAsync(vm);
            return RedirectToAction("Index");
        }
    }
}
