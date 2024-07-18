using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheSideHustle.Models;

namespace TheSideHustle.Controllers
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

        public IActionResult LogIn()
        {
            return null;
        }


        [HttpPost]
        public IActionResult Authenticate(string email, string password)
        {
            return View("HomePage");
        }

        [HttpPost]
        public IActionResult SignUp()
        {
            return View();
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
