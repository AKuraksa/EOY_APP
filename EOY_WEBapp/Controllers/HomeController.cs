using EOY_WEBapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EOY_WEBapp.Controllers
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
            // Vytvoření instance modelu a nastavení dat
            var model = new MyViewModel
            {
                Message = "Vítejte na našem webu!",
                // Další vlastnosti modelu můžete nastavit zde
            };

            // Nahrání pohledu a předání modelu
            return View(model);
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