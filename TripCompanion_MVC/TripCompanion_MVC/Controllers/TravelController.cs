using Microsoft.AspNetCore.Mvc;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;
using TripCompanion_MVC.Services;

namespace TripCompanion_MVC.Controllers
{
    public class TravelController : Controller
    {
       
        private IUserService _userService;
        private ITripService _tripService;
        private SessionManager _sessionManager;
        

        #region Ctor
        public TravelController(IUserService userService, ITripService tripService,SessionManager sessionManager)
        {
           
            _tripService = tripService;
            _userService = userService;
            _sessionManager = sessionManager;
           
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TravelPage()
        {
            if (_sessionManager.IdUser == null)// Should'nt happen but just in case
            {
                TempData["Message"] = "Error: Vous n'êtes pas identifié";
                return RedirectToAction("Index", "Home");
            } 
            User user = await _userService.GetUserById((int)_sessionManager.IdUser);  
            
            IEnumerable<Trip> listTrip = await _tripService.GetAllTripByUser((int)_sessionManager.IdUser);

            return View(user);
        }


        // Controller needed for the TravelPage View to make an ajax call. Return the ViewComponent "Steps" and "Todos".
        [HttpGet]
        public IActionResult GetStepByTripVC(int idTrip)
        {
            return ViewComponent("Steps", idTrip);
        }

        
        [HttpGet]
        public IActionResult GetTodoByStepVC(int idStep)
        {
            return ViewComponent("Todos", idStep);
        }


    }
}
