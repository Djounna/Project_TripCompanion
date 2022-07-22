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
        public async Task<IActionResult> Create()
        {           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]TripForm tripForm)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Warning : Erreur dans le formualaire";
                return View(tripForm);
            }

             await _tripService.CreateTrip(tripForm);
            TempData["Message"] = "Success : Votre voyage a été ajouté avec succès";
            return RedirectToAction("TravelPage","Travel");
         }
        #endregion

        #region Update
        public async Task<IActionResult> Edit(int idTrip)
        {
            Trip trip = await _tripService.GetTripById(idTrip);
            return View(trip);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Trip trip)
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
        #endregion
        #region Delete
        public async Task<IActionResult> Delete(int idTrip)
        {
            Trip trip = await _tripService.GetTripById(idTrip);
            return View(trip);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Trip trip)
        {
            await _tripService.DeleteTrip(trip.IdTrip);
            return RedirectToAction("TravelPage", "Travel");
        }
        #endregion
    }
}
