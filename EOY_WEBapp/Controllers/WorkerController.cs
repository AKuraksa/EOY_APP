using EOY_WEBapp.Data;
using EOY_WEBapp.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

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
        
         public async Task<IActionResult> CreateAction()
        {
            return View("Create");
        }
        public async Task<IActionResult> CreateWorker(WorkerModel worker)
        {
            

            if (!string.IsNullOrWhiteSpace(worker.AuthentificatorID)
                || !string.IsNullOrWhiteSpace(worker.WorkerFirstName)
                || !string.IsNullOrWhiteSpace(worker.WorkerLastName))
            {
                var workersList = await _fce.EOYrestResponse<WorkerModel>(EOY_Values.WORKERS_CONTROLLER, EOY_Values.GET);
                var passwordExist = workersList.Where(x => x.AuthentificatorID == worker.AuthentificatorID).Any();
                if(!passwordExist)
                {
                    try
                    {
                        var myClient = new RestClient(_fce.GetApiAdress(EOY_Values.WORKERS_CONTROLLER, EOY_Values.POST));
                        var request = new RestRequest();
                        request.AddQueryParameter("workerFirstName", worker.WorkerFirstName);
                        request.AddQueryParameter("workerLastName", worker.WorkerLastName);
                        request.AddQueryParameter("authentificatorId", worker.AuthentificatorID);
                        var response = await myClient.PostAsync(request);

                        return RedirectToAction("IndexWorker", "Worker");
                    }
                    catch (Exception ex)
                    {
                        return View("Create");
                    }

                }
                else
                    return View("Create");
            }
            else
                return View("Create");

        }
        
    }
}
