using Microsoft.AspNetCore.Mvc;

namespace EOY_WEBapp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
