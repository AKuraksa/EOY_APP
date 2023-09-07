using EOY_WEBapp.Dto;
using EOY_WEBapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RestSharp;
using System.Text.Json;

namespace EOY_WEBapp.Controllers
{
    public class LoginController : Controller
    {
        private readonly Parameters _parameters = new Parameters();

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
        [HttpGet]
        public IActionResult Index(LoginModel loginModel)
        {

            if (ModelState.IsValid)
            {
                if(!ModelState.IsValid)
                {
                        var myClient = new RestClient();
                        var request = new RestRequest();
                        request.AddQueryParameter("username", loginModel.Username);
                        request.AddQueryParameter("password", loginModel.Password);
                        var response = myClient.Get(request);
                        var content = response.Content;
                        var user = JsonSerializer.Deserialize<List<LoginModel>>(content);
                        if (user.Count() == 1)
                        {
                            return View(user);

                return StatusCode(500, "Došlo k chybě při volání vzdáleného API.");
                        }
                        else
                        {
                            return Error();
                        }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {

                    
                }
            }

            // Pokud došlo k chybám validace, zobrazte formulář znovu s chybami
            return View(loginModel);
        }
       private async Task GetUser(LoginModel loginModel)
        {
           
                return StatusCode((int)response.StatusCode, "Došlo k chybě při volání vzdáleného API.");
            }
        }
       
    }
        
}