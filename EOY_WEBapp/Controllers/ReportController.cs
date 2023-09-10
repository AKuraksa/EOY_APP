using EOY_WEBapp.Data;
using EOY_WEBapp.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace EOY_WEBapp.Controllers
{
    public class ReportController : Controller
    {
        private readonly EOY_Functions _fce = new EOY_Functions();

        public async Task<IActionResult> Index()
        {
            List<IssueModels> listErrors = await ListErrors();
            return View(listErrors);

        }

        private async Task<List<IssueModels>> ListErrors()
        {
            var myClient = new RestClient(_fce.GetApiAdress(EOY_Values.HISTORY_ERRORS_CONTROLLER,EOY_Values.GET));
            var request = new RestRequest();
            var response = myClient.Get(request);
            var content = response.Content;
         
            var currentDate = DateTime.UtcNow;
            if (content.Any())
            {
                var listErrors = JsonSerializer.Deserialize<List<IssueModels>>(content);
                return listErrors;
            }
            else
                return null;
        }
    }
}
