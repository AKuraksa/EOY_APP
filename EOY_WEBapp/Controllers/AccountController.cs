using EOY_WEBapp.Data;
using EOY_WEBapp.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace EOY_WEBapp.Controllers
{
    public class AccountController : Controller
    {
        private readonly Parameters _parameters = new Parameters();
        public IActionResult Index()
        {
            return View(); // Přesměrování na domovskou stránku
        }
       
        public IActionResult Editor()
        {
            List<LoginModel> usersList = UsersList();
            return View(usersList);
        }

        public IActionResult Edit()
        {
            return RedirectToAction("Editor");
        }

        public IActionResult DeleteAccount(LoginModel loginModel)
        {
            var myClient = new RestClient($"{_parameters.GetApiAdress()}/DeleteByID");
            var request = new RestRequest();
            request.AddQueryParameter("id", loginModel.id);
            var response = myClient.Delete(request);

            // Po smazání účtu přesměrovat zpět na Editor
            return RedirectToAction("Editor");
        }
        public IActionResult CreateAccount(LoginModel loginModel)
        {
            return View("CreateAccount");
        }
        
        public IActionResult Create(LoginModel loginModel)
        {
            var myClient = new RestClient($"{_parameters.GetApiAdress()}/CreateLogin");
            var request = new RestRequest();
            request.AddQueryParameter("username", loginModel.Username);
            request.AddQueryParameter("password", loginModel.Password);
            request.AddQueryParameter("email", loginModel.Email);
            request.AddQueryParameter("firstName", loginModel.FirstName);
            request.AddQueryParameter("lastName", loginModel.LastName);
            request.AddQueryParameter("admin", loginModel.Permission);
            var response = myClient.Post(request);
            return RedirectToAction("Editor");
        }



        private List<LoginModel> UsersList()
        {
            var myClient = new RestClient($"{_parameters.GetApiAdress()}/All_Data_FROM_Logins");
            var request = new RestRequest();
            var response = myClient.Get(request);
            var content = response.Content;
            var usersList = JsonSerializer.Deserialize<List<LoginModel>>(content);
            return usersList;
        }
    }
}
