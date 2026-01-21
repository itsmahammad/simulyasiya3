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
        public async Task<IActionResult> Create(ProjectCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Departments = (await _service.GetCreateAsync()).Departments;
                return View(vm);
            }
            await _service.CreateAsync(vm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var vm = await _service.GetUpdateAsync(id);
            if(vm == null)
            {
                return NotFound();
            }
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProjectUpdateVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Departments = (await _service.GetUpdateAsync(vm.Id)).Departments;
                vm.CurrentImageUrl = (await _service.GetUpdateAsync(vm.Id)).CurrentImageUrl;
                return View(vm);
                
            }
            await _service.UpdateAsync(vm);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
