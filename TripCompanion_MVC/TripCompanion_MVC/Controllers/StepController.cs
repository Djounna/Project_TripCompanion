using Microsoft.AspNetCore.Mvc;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;

namespace StepCompanion_MVC.Controllers
{
    public class StepController : Controller
    {

        private IApiConsume _apiConsume;
        private IStepService _stepService;
        #region Ctor
        public StepController(IApiConsume apiConsume)
        {
            _apiConsume = apiConsume;
        }
        #endregion

        #region Crud
        public async Task<IActionResult> AllSteps()
        {
            IEnumerable<Step> listStep = await _stepService.GetAllStep();
            return View(listStep);
        }
        public async Task<IActionResult> StepById(int id)
        {
            Step Step = await _stepService.GetStepById(id);
            return View(Step);
        }
        #endregion



        #region Create
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] StepForm stepForm)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Warning : Erreur dans le formualaire";
                return View(stepForm);
            }

            await _stepService.CreateStep(stepForm);
            TempData["Message"] = "Success : Votre voyage a été ajouté avec succès";
            return RedirectToAction("TravelPage", "Travel");
        }
        #endregion

        #region Update
        public async Task<IActionResult> Edit(int idStep)
        {
            Step Step = await _stepService.GetStepById(idStep);
            return View(Step);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Step step)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Warning : Erreur dans le formulaire ";
                return View(step);
            }
            await _stepService.UpdateStep(step);
            TempData["Message"] = "Success : Votre voyage a été mis à jour avec succès";
            return RedirectToAction("TravelPage", "Travel");

        }
        #endregion
        #region Delete
        public async Task<IActionResult> Delete(int idStep)
        {
            Step Step = await _stepService.GetStepById(idStep);
            return View(Step);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Step Step)
        {
            await _stepService.DeleteStep(Step.IdStep);
            return RedirectToAction("TravelPage", "Travel");
        }
        #endregion





    }
}
