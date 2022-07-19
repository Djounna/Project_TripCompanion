using Microsoft.AspNetCore.Mvc;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;

namespace TripCompanion_MVC.ViewComponents
{
    [ViewComponent(Name="Trips")]
    public class TripsViewComponent : ViewComponent
    {

        private ITripService _tripService;

        #region Ctor
        public TripsViewComponent(ITripService tripService)
        {
            _tripService = tripService;
           
        }
        #endregion

        public async Task<IViewComponentResult> InvokeAsync(int idUser)
        {
            IEnumerable<Trip> listTrip = await _tripService.GetAllTripByUser(idUser);
            return View(listTrip);
        }


    }
}
