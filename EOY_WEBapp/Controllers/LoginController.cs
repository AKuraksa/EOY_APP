using EOY_WEBapp.Models;
using EOY_WEBapp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RestSharp;
using System.Text.Json;
using NuGet.Packaging;
using System.Collections.Generic;

namespace EOY_WEBapp.Controllers
{
	public class LoginController : Controller
	{
		private readonly EOY_Values _values = new EOY_Values();
		private readonly EOY_Functions _fce = new EOY_Functions();

		private readonly ILogger<LoginController> _logger;

		public LoginController(ILogger<LoginController> logger)
		{
			_logger = logger;
		}


		public IActionResult Index()
		{
           
            return View();

		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginModel loginModel)
		{

			try
			{
				var myClient = new RestClient(_fce.UniversalApiAdress("FindUser"));
				var request = new RestRequest();
				request.AddQueryParameter("username", loginModel.Username);
				request.AddQueryParameter("password", loginModel.Password);
				var response = myClient.Get(request);
				var content = response.Content;
				var user =  JsonSerializer.Deserialize<List<LoginModel>>(content);
				var userdata = user.FirstOrDefault();
				if(user != null)
				{
                    TempData["Fullname"] = userdata.FullName;

                    if (user.Count() == 1)
                    {
                        return RedirectToAction("Index", "Home"); // Přesměrování na domovskou stránku
                    }
                }
			}
			catch (Exception e)
			{
				// Zde byste měli zalogovat chybu
				ModelState.AddModelError("", "Došlo k chybě při přihlašování.");

			}

			return  View(); // Znovu zobrazit přihlašovací formulář s chybami (pokud jsou)
		}

		

	}
}

