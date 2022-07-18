using TripCompanion_MVC.Models;

namespace TripCompanion_MVC.Interfaces
{
    public interface IAccountService
    {
        void Logout();
        Task<ConnectedUser> CheckLogin(string username, string password);
        Task<User> SignUp(UserForm userForm);




    }
}
