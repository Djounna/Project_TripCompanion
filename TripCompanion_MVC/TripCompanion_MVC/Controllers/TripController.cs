using Microsoft.AspNetCore.Mvc;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;
using TripCompanion_MVC.Services;

namespace TripCompanion_MVC.Controllers
{
    public class TripController : Controller
    {
        private IApiConsume _apiConsume;
        private readonly SessionManager _sessionManager;
        private ITripService _tripService;

        #region Ctor
        public TripController(ITripService tripService, IApiConsume apiConsume, SessionManager sessionManager)
        {
            _tripService = tripService;
            _apiConsume = apiConsume;
            _sessionManager = sessionManager;
        }
        #endregion

        #region Crud
        public async Task<IActionResult> AllTrips()
        {
            IEnumerable<Trip> listTrip = await _tripService.GetAllTrip();
            return View(listTrip);
        }
        
        public async Task<IActionResult> AllTripsByUser(int idUser) // En cours
        {
            IEnumerable<Trip> listTrip = await _tripService.GetAllTripByUser(idUser);                
            return View(listTrip);
        }

        public async Task<IActionResult> TripById(int id)
        {
            Trip trip = await _tripService.GetTripById(id); 
            return View(trip);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]TripForm tripForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Message"] = "Warning : Erreur dans le formulaire";
                    return View(tripForm);
                }

                await _tripService.CreateTrip(tripForm);
                TempData["Message"] = "Success : Votre voyage a été ajouté avec succès";
                return RedirectToAction("TravelPage", "Travel");
            }
            catch (Exception)
            {
                TempData["Message"] = "Error: Un problème s'est produit ";
                return RedirectToAction("TravelPage", "Travel");
            }
         }
        #endregion

        #region Update
        public async Task<IActionResult> Edit(int idTrip)
        {
            try
            {
                Trip trip = await _tripService.GetTripById(idTrip);
                return View(trip);
            }
            catch (Exception)
            {
                TempData["Message"] = "Error: Un problème s'est produit ";
                return RedirectToAction("TravelPage", "Travel");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Trip trip)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Message"] = "Warning : Erreur dans le formulaire ";
                    return View(trip);
                }
                await _tripService.UpdateTrip(trip);
                TempData["Message"] = "Success : Votre voyage a été mis à jour avec succès";
                return RedirectToAction("TravelPage", "Travel");
            }
            catch (Exception)
            {
                TempData["Message"] = "Error: Un problème s'est produit ";
                return RedirectToAction("TravelPage", "Travel");
            }

        }
        #endregion
        #region Delete
        //public async Task<IActionResult> Delete(int idTrip)
        //{
        //    Torip trip = await _tripService.GetTodoById(idTrip);
        //    return View(trip);
        //}
        public async Task<IActionResult> Delete(int idTrip)
        {
            try
            {
                await _tripService.DeleteTrip(idTrip);
                TempData["Message"] = "Success : Ce voyage a bien été supprimé";
                return RedirectToAction("TravelPage", "Travel");
            }
            catch (Exception)
            {
                TempData["Message"] = "Error: Un problème s'est produit ";
                return RedirectToAction("TravelPage", "Travel");
            }
        }
        
        #endregion
    }
}
