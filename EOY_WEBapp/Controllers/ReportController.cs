using EOY_WEBapp.Data;
using EOY_WEBapp.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace EOY_WEBapp.Controllers
{
    public class ReportController : Controller
    {
        private readonly Parameters _parameters = new Parameters();

        public async Task<IActionResult> Index()
        {
            List<IssueModels> listErrors = await ListErrors();
            return View(listErrors);

        }

        private async Task<List<IssueModels>> ListErrors()
        {
            var myClient = new RestClient($"{_parameters.GetApiAdress()}/GetAllErrors");
            var request = new RestRequest();
            var response = myClient.Get(request);
            var content = response.Content;
            var listErrors = JsonSerializer.Deserialize<List<IssueModels>>(content);
            var currentDate = DateTime.UtcNow;

            return listErrors;
        }
    }
}
