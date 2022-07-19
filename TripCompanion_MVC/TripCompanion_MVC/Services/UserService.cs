using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;

namespace TripCompanion_MVC.Services
{
    public class UserService : IUserService
    {
        private IApiConsume _apiConsume;
        private readonly SessionManager _sessionManager;
        #region Ctor
        public UserService(IApiConsume apiConsume, SessionManager sessionManager)
        {
            _apiConsume = apiConsume;
            _sessionManager = sessionManager;
        }
        #endregion

        public async Task<User> GetUserById(int id)
        {
            User user = await _apiConsume.GetOne<User>("Trip/GetUserById" + id);
            return user;
        }

    }
}
