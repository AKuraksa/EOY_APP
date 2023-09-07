using EOY_WEBapp.Models;
using EOY_WEBapp.Data;
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

            return View(new LoginModel());
           
        }

        [HttpGet]
        public IActionResult LoginAction(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    var myClient = new RestClient($"{_parameters.GetApiAdress()}/FindUser");
                    var request = new RestRequest();
                    request.AddQueryParameter("username", loginModel.Username);
                    request.AddQueryParameter("password", loginModel.Password);
                    var response = myClient.Get(request);
                    var content = response.Content;
                    var user = JsonSerializer.Deserialize<List<LoginModel>>(content);
                    if (user.Count() == 1)
                    {
                        return View("Home");
                    }
                    
                }
                catch (Exception e)
                {

                }
             
            }
            return View("Home");
        }





    }
}

