using TripCompanion_MVC.Models;

namespace TripCompanion_MVC.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
    }
}
