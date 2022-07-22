using Microsoft.AspNetCore.Mvc;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;
using TripCompanion_MVC.Services;

namespace TripCompanion_MVC.ViewComponents
{
    [ViewComponent(Name = "Steps")]
    public class StepsViewComponent : ViewComponent
    {
        private IStepService _stepService;
        private SessionManager _sessionManager;
        #region Ctor
        public StepsViewComponent(IStepService stepService, SessionManager sessionManager)
        {
            _stepService = stepService;
            _sessionManager = sessionManager;
        }
        #endregion

        public async Task<IViewComponentResult> InvokeAsync(int idTrip)
        {
            if (_sessionManager.IdUser == 0)
            {
                TempData["ErrorMessageVCSteps"] = "Error : vous n'êtes pas identifié";
                return View();
            }
            IEnumerable<Step> listStep = await _stepService.GetAllStepByTrip(idTrip);
            ViewBag.IdTrip = idTrip;
            return View(listStep);
        }


    }
}
