using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;

namespace TripCompanion_MVC.Controllers
{
    public class HomeController : Controller
    {
        private IApiConsume _apiConsume;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IApiConsume apiConsume)
        {
            _logger = logger;
            _apiConsume = apiConsume;
        }

        public IActionResult Index()
        {
            return View();
        }

       

        //Login
        public IActionResult Login()
        {
            return(View());
        }
        public async Task<IActionResult> CheckLogin([FromForm] UserLogin userLogin)
        {
            ConnectedUser connectedUser = await _apiConsume.GetOne<ConnectedUser>("User/Login/"+userLogin.Username+"/"+userLogin.Password);

            if(connectedUser == null)
            {
                return RedirectToAction("Index");
            }

            HttpContext.Session.SetString("Token",connectedUser.Token);
            HttpContext.Session.SetInt32("IdUser", connectedUser.IdUser);

            return RedirectToAction("Index");

        }



        //Logout
        public void Logout()
        {
            throw new NotImplementedException();
        }






        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}