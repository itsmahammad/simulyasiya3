using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using simulyasiya3.Models;
using simulyasiya3.Services.Interfaces;
using simulyasiya3.ViewModels.ProjectVMs;

namespace simulyasiya3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectService _service;
        public HomeController(IProjectService service)
        {
            _service = service;
        }

        public async Task<IActionResult>  Index()
        {
            var projects = await _service.ShowUIAsync();
            return View(projects);
        }

    }
}
