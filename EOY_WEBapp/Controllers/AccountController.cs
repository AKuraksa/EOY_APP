using EOY_WEBapp.Data;
using EOY_WEBapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using RestSharp;
using System.Text.Json;

namespace EOY_WEBapp.Controllers
{
    public class AccountController : Controller
    {
        private readonly EOY_Functions _fce = new EOY_Functions();
       
       
        public async Task<IActionResult> Index()
        {
            var usersList = await _fce.EOYrestResponse<LoginModel>(EOY_Values.LOGIN_CONTROLLER,EOY_Values.GET);
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
        
        public async Task<IActionResult> Create(LoginModel loginModel)
        {
            var myClient = new RestClient(_fce.GetApiAdress(EOY_Values.LOGIN_CONTROLLER,EOY_Values.POST));
            var request = new RestRequest();
            request.AddQueryParameter("username", loginModel.Username);
            request.AddQueryParameter("password", loginModel.Password);
            request.AddQueryParameter("email", loginModel.Email);
            request.AddQueryParameter("firstName", loginModel.FirstName);
            request.AddQueryParameter("lastName", loginModel.LastName);
            request.AddQueryParameter("admin", loginModel.Permission);
            var response = await myClient.PostAsync(request);
            return RedirectToAction("Index");
        }

    }
}
