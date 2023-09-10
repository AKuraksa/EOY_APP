using EOY_WEBapp.Data;
using EOY_WEBapp.Dto;
using EOY_WEBapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using RestSharp;
using System.Text.Json;

namespace EOY_WEBapp.Controllers
{
    public class ReportController : Controller
    {
        private readonly EOY_Functions _fce = new EOY_Functions();

        public async Task<IActionResult> Index()
        {
            var result = await _fce.EOYrestResponse<IssueModels>(EOY_Values.HISTORY_ERRORS_CONTROLLER, EOY_Values.GET);
            return View(result);

        }

       
    }
}
