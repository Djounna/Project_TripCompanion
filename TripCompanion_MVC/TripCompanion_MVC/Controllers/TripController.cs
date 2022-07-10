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

      

        [Route("/GetAllTrips")]

        public async Task<IActionResult> GetAllTrips()
        {
            IEnumerable<Trip> listTrip = await _apiConsume.GetMany<Trip>("/Trip/GetAllTrips");

            return View(listTrip);
        }


    }
}
