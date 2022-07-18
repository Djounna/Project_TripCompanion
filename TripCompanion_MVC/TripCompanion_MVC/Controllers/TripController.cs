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
    }
}
