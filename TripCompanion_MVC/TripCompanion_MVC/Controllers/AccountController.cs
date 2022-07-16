using Microsoft.AspNetCore.Mvc;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;
using TripCompanion_MVC.Services;

namespace TripCompanion_MVC.Controllers
{
    public class AccountController : Controller
    {

        private IApiConsume _apiConsume;
        private readonly SessionManager _sessionManager;
        private readonly ILogger<HomeController> _logger;

        #region Ctor
        public AccountController(ILogger<HomeController> logger, IApiConsume apiConsume, SessionManager sessionManager)
        {
            _logger = logger;
            _apiConsume = apiConsume;
            _sessionManager = sessionManager;
        }
        #endregion

        #region SignUp
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromForm]UserForm userForm)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Error : le formulaire n'a pas été correctement complété";
                return RedirectToAction("Index", "Home");
            }

            // TODO: CheckUserExists; if it is => Error message
            //TempData["Message"] = "Warning: Ce compte utilisateur existe déja, vous pouvez vous identifier.";
            //return RedirectToAction("Login");


            User userToPost = new User
            {
                IdUser = 0,
                Username = userForm.Username,
                Email = userForm.Email,
                Password = userForm.Password
            };

            User createdUser = await _apiConsume.Post<User>("User", userToPost);

            TempData["Message"] = "Success : Votre compte a été créé avec succès, vous pouvez maintenant vous identifier";

            return RedirectToAction("Login");

        }
        #endregion

        #region Login
        public IActionResult Login()
        {
            return (View());
        }
        public async Task<IActionResult> CheckLogin([FromForm] UserLogin userLogin)
        {
            try  // TODO if possible: Try Catch pas propre, à améliorer.
            {
                // TODO: validation sur modelState ?

                ConnectedUser connectedUser = await _apiConsume.GetOne<ConnectedUser>("User/Login/" + userLogin.Username + "/" + userLogin.Password);

                if (connectedUser == null)
                {
                    TempData["Message"] = "Error : Username ou Password incorrect";
                    return RedirectToAction("Index", "Home");
                }

                _sessionManager.Token = connectedUser.Token;
                _sessionManager.Role = connectedUser.Role;
                _sessionManager.IdUser = connectedUser.IdUser;             

                return RedirectToAction("Index","Home");
            }
            catch (Exception)
            {
                TempData["Message"] = "Error : Username ou Password incorrect";
                return RedirectToAction("Index","Home");
            }
        }
        #endregion
        #region Logout
        public IActionResult Logout()
        {
            _sessionManager.clear();

            return RedirectToAction("Index","Home");
        }
        #endregion

    }
}
