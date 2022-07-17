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
        #region Ctor
        public TripController(IApiConsume apiConsume, SessionManager sessionManager)
        {
            _apiConsume = apiConsume;
            _sessionManager = sessionManager;
        }
        #endregion

        #region Crud
        public async Task<IActionResult> AllTrips()
        {
            IEnumerable<Trip> listTrip = await _apiConsume.GetMany<Trip>("Trip", _sessionManager.Token);
            return View(listTrip);
        }

        public async Task<IActionResult> AllTripsByUser(int userId) // En cours
        {
            IEnumerable<Trip> listTrip = await _apiConsume.GetMany<Trip>("Trip/GetAllTripsByUser/"+userId, _sessionManager.Token);
            return View(listTrip);
        }
        public async Task<IActionResult> TripById(int id)
        {
            Trip trip = await _apiConsume.GetOne<Trip>("Trip/GetTripById"+id);
            return View(trip);
        }

        
        #endregion
    }
}
