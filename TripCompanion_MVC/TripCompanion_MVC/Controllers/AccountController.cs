using Microsoft.AspNetCore.Mvc;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;
using TripCompanion_MVC.Services;

namespace TripCompanion_MVC.Controllers
{
    public class AccountController : Controller
    {

        private IApiConsume _apiConsume;
        private IAccountService _accountService;
        private readonly SessionManager _sessionManager;
        private readonly ILogger<HomeController> _logger;

        #region Ctor
        public AccountController(IAccountService accountService, ILogger<HomeController> logger, IApiConsume apiConsume, SessionManager sessionManager)
        {
            _logger = logger;
            _apiConsume = apiConsume;
            _sessionManager = sessionManager;
            _accountService = accountService;
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

            try  // TODO if possible: Try Catch pas propre, à améliorer.
            {
                if (!ModelState.IsValid)
                {
                    TempData["Message"] = "Error : le formulaire n'a pas été correctement complété";
                    return RedirectToAction("Index", "Home");
                }

                User createdUser = await _accountService.SignUp(userForm);
                // TODO: CheckUserExists; if it is => Error message
                //TempData["Message"] = "Warning: Ce compte utilisateur existe déja, vous pouvez vous identifier.";
                //return RedirectToAction("Login");
                TempData["Message"] = "Success : Votre compte a été créé avec succès, vous pouvez maintenant vous identifier";

                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                TempData["Message"] = "Error : Une erreur s'est produite lors de votre enregistrement, veuillez réessayer";
                return RedirectToAction("Index", "Home");
            }
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

                ConnectedUser? connectedUser = await _accountService.CheckLogin(userLogin.Username, userLogin.Password);

                if (connectedUser == null)
                {
                    TempData["Message"] = "Error : Username ou Password incorrect";
                    return RedirectToAction("Index", "Home");
                }           

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
            _accountService.Logout();

            return RedirectToAction("Index","Home");
        }
        #endregion

    }
}
