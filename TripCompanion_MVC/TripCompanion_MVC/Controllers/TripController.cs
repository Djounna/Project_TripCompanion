using Microsoft.AspNetCore.Mvc;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;

namespace TripCompanion_MVC.Controllers
{
    public class TripController : Controller
    {
        private IApiConsume _apiConsume;
        #region Ctor
        public TripController(IApiConsume apiConsume)
        {
            _apiConsume = apiConsume;
        }
        #endregion

        #region Crud
        public async Task<IActionResult> AllTrips()
        {
            IEnumerable<Trip> listTrip = await _apiConsume.GetMany<Trip>("Trip");
            return View(listTrip);
        }

        public async Task<IActionResult> AllTripsByUser(int userId) // En cours
        {
            IEnumerable<Trip> listTrip = await _apiConsume.GetMany<Trip>("Trip/GetAllTripsByUser/"+userId);
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
