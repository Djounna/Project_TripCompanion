using Microsoft.AspNetCore.Mvc;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;

namespace StepCompanion_MVC.Controllers
{
    public class StepController : Controller
    {

        private IApiConsume _apiConsume;
        #region Ctor
        public StepController(IApiConsume apiConsume)
        {
            _apiConsume = apiConsume;
        }
        #endregion

        #region Crud
        public async Task<IActionResult> AllSteps()
        {
            IEnumerable<Step> listStep = await _apiConsume.GetMany<Step>("Step");
            return View(listStep);
        }
        public async Task<IActionResult> StepById(int id)
        {
            Step Step = await _apiConsume.GetOne<Step>("Step/GetStepById/" + id);
            return View(Step);
        }
        #endregion

    }
}
