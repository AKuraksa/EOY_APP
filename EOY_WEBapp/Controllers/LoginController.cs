using EOY_WEBapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EOY_WEBapp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
       
        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        


        }

        public IActionResult Index()
        {
            // Vytvoření instance modelu a nastavení dat
          

            // Nahrání pohledu a předání modelu
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