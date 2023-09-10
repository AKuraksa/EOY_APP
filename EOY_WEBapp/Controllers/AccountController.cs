using EOY_WEBapp.Data;
using EOY_WEBapp.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace EOY_WEBapp.Controllers
{
    public class AccountController : Controller
    {
        private readonly EOY_Functions _fce = new EOY_Functions();
       
       
        public IActionResult Index()
        {
            List<LoginModel> usersList = UsersList();
            return View(usersList);
        }

        public IActionResult DeleteAccount(LoginModel loginModel)
        {
            var myClient = new RestClient(_fce.GetApiAdress(EOY_Values.LOGIN_CONTROLLER,EOY_Values.DELETE));
            var request = new RestRequest();
            request.AddQueryParameter("id", loginModel.id);
            var response = myClient.Delete(request);

            // Po smazání účtu přesměrovat zpět na Editor
            return RedirectToAction("Index");
        }
        public IActionResult CreateAccount(LoginModel loginModel)
        {
            return View("CreateAccount");
        }
        
        public IActionResult Create(LoginModel loginModel)
        {
            var myClient = new RestClient(_fce.GetApiAdress(EOY_Values.LOGIN_CONTROLLER,EOY_Values.POST));
            var request = new RestRequest();
            request.AddQueryParameter("username", loginModel.Username);
            request.AddQueryParameter("password", loginModel.Password);
            request.AddQueryParameter("email", loginModel.Email);
            request.AddQueryParameter("firstName", loginModel.FirstName);
            request.AddQueryParameter("lastName", loginModel.LastName);
            request.AddQueryParameter("admin", loginModel.Permission);
            var response = myClient.Post(request);
            return RedirectToAction("Index");
        }



        private List<LoginModel> UsersList()
        {
            var myClient = new RestClient(_fce.GetApiAdress(EOY_Values.LOGIN_CONTROLLER,EOY_Values.GET));
            var request = new RestRequest();
            var response = myClient.Get(request);
            var content = response.Content;
            if (content.Any())
            {
                var usersList = JsonSerializer.Deserialize<List<LoginModel>>(content);
                return usersList;
            }
            else
                return null;
           
        }
    }
}
