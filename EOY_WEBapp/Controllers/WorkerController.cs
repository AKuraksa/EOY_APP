using EOY_WEBapp.Data;
using EOY_WEBapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EOY_WEBapp.Controllers
{
    public class WorkerController : Controller
    {
        EOY_Functions _fce = new EOY_Functions();
        public async Task<IActionResult> IndexWorker()
        {
            var listWorkers = await _fce.EOYrestResponse<WorkerModel>(EOY_Values.WORKERS_CONTROLLER, EOY_Values.GET);
            return View(listWorkers);
        }
    }
}
