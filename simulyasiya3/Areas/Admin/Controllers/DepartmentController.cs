using Microsoft.AspNetCore.Mvc;
using simulyasiya3.Services.Interfaces;
using simulyasiya3.ViewModels.DepartmentVMs;

namespace simulyasiya3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _service.ShowAdminAsync();
            return View(departments);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateUpdateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _service.CreateAsync(vm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete()
        {
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
