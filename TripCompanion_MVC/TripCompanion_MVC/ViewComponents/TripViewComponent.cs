using Microsoft.AspNetCore.Mvc;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;
using TripCompanion_MVC.Services;

namespace TripCompanion_MVC.ViewComponents
{
    [ViewComponent(Name="Trips")]
    public class TripsViewComponent : ViewComponent
    {
        private ITripService _tripService;
        private SessionManager _sessionManager;
        #region Ctor
        public TripsViewComponent(ITripService tripService, SessionManager sessionManager)
        {
            _tripService = tripService;
            _sessionManager = sessionManager;
        }
        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if(_sessionManager.IdUser == 0)
            {
                TempData["ErrorMessageVCTrips"] = "Error : vous n'êtes pas identifié";
                return View();
            }
            IEnumerable<Trip> listTrip = await _tripService.GetAllTripByUser((int)_sessionManager.IdUser);
            return View(listTrip);
        }


    }
}
