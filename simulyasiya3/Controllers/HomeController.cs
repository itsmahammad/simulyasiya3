using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using simulyasiya3.Models;

namespace simulyasiya3.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

    }
}
