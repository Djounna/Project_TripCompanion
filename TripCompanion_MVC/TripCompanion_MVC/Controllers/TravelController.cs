using Microsoft.AspNetCore.Mvc;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;
using TripCompanion_MVC.Services;
using TripCompanion_MVC.Services.ApiExternal;

namespace TripCompanion_MVC.Controllers
{
    public class TravelController : Controller
    {
       
        private IUserService _userService;
        private ITripService _tripService;
        private SessionManager _sessionManager;
        
        private GeoapifyAPI _geoapifyApi;
        private OpenWeatherMapAPI _openWeatherMapApi;
        
        #region Ctor
        public TravelController(IUserService userService, ITripService tripService,SessionManager sessionManager, GeoapifyAPI geoapifyAPI, OpenWeatherMapAPI openWeatherMapAPI)
        {          
            _tripService = tripService;
            _userService = userService;
            _sessionManager = sessionManager;
            _geoapifyApi = geoapifyAPI;
            _openWeatherMapApi = openWeatherMapAPI;          
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


        #region ViewComponents controllers
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

        #endregion

        #region ExternalAPI controllers

        public async Task<IActionResult> MapCoordinates(string location)
        {
            GeoapifyAPI.CoordonateResult result = await _geoapifyApi.Search(location);

            // TODO Cleanup this ♥
            return Ok(new
            {
                lat = result.Lat,
                lon = result.Long
                               
            });
        }

        public async Task<IActionResult> WeatherMap(string lat, string lon)
        {
            OpenWeatherMapAPI.WeatherResult result = await _openWeatherMapApi.Search(lat, lon);

            return Ok(new
            {
                temp = result.temp,
                hum = result.hum
            });
        }

        #endregion

    }
}
