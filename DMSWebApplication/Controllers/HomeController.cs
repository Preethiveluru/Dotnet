using System.Diagnostics;
using DMSWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace DMSWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult createdms( string name ,string Qualification,string speciality)
        {
            TempData["name"] = name;
            TempData["Qualification"] = Qualification;
            TempData["speciality"] = speciality;

            return RedirectToAction("Create", "DMS");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
