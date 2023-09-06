using EOY_WEBapp.Dto;
using EOY_WEBapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RestSharp;
using EOY_WEBapp.Data;
using System.Net;
using System.Reflection;

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
            //// Vytvoření instance modelu a nastavení dat
            //var model = new MyViewModel
            //{
            //    Message = "Vítejte na našem webu!",
            //    // Další vlastnosti modelu můžete nastavit zde
            //};

            //// Nahrání pohledu a předání modelu
            return View(/*model*/);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LogIn(LoginDto loginDto)
        {
            if (loginDto == null || string.IsNullOrWhiteSpace(loginDto.Username) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return BadRequest("Neplatný požadavek.");
            }

        
            var myClient = new RestClient($"{_parameters.GetApiAdress()}/FindUser");
            var request = new RestRequest();

          
            request.AddParameter("username", loginDto.Username);
            request.AddParameter("password", loginDto.Password);

        
            var response = myClient.Get(request);

        
            if (response.ErrorException != null)
            {

                return StatusCode(500, "Došlo k chybě při volání vzdáleného API.");
            }

       
            if (response.StatusCode == HttpStatusCode.OK)
            {
              
                var content = response.Content;

                return View("Menu");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
               
               
                
                return View("Index");
            }
            else
            {
               
                return StatusCode((int)response.StatusCode, "Došlo k chybě při volání vzdáleného API.");
            }
        }
       
    }
        
}