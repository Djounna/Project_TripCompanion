using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;

namespace TripCompanion_MVC.Services
{
    public class AccountService : IAccountService
    {

        private IApiConsume _apiConsume;
        private readonly SessionManager _sessionManager;
        #region Ctor
        public AccountService(IApiConsume apiConsume, SessionManager sessionManager)
        {
            _apiConsume = apiConsume;
            _sessionManager = sessionManager;
        }
        #endregion

        public async Task<ConnectedUser> CheckLogin(string username, string password)
        {
            ConnectedUser? connectedUser = await _apiConsume.GetOne<ConnectedUser>("User/Login/" + username + "/" + password);
             
            if(connectedUser != null)
            {
                _sessionManager.Token = connectedUser.Token;
                _sessionManager.Role = connectedUser.Role;
                _sessionManager.IdUser = connectedUser.IdUser;
                _sessionManager.UserName = connectedUser.Username;
            }
            return connectedUser; // TODO: See if necessary to return a connectedUser ?
        }
        public void Logout()
        {
            _sessionManager.clear();
        }
        public async Task<User> SignUp(UserForm userForm)
        {
            User userToPost = new User
            {
                IdUser = 0,
                Username = userForm.Username,
                Email = userForm.Email,
                Password = userForm.Password
            };
            User createdUser = await _apiConsume.Post<User>("User", userToPost);
            return createdUser;
        }
    }
}
