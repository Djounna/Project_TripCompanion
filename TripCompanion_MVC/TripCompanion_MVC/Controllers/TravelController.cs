using Microsoft.AspNetCore.Mvc;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;
using TripCompanion_MVC.Services;

namespace TripCompanion_MVC.Controllers
{
    public class TravelController : Controller
    {
        private IApiConsume _apiConsume;
        private readonly SessionManager _sessionManager;

        #region Ctor
        public TravelController(IApiConsume apiConsume, SessionManager sessionManager)
        {
            _apiConsume = apiConsume;
            _sessionManager = sessionManager;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TravelPage(int userId)
        {
            User user = await _apiConsume.GetOne<User>("User/GetUserById"+userId);

            IEnumerable<Trip> listTrip = await _apiConsume.GetMany<Trip>("Trip/GetAllTripsByUser/" + userId, _sessionManager.Token);

            return View(user);
        }




    }
}
