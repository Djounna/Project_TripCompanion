using TripCompanion_MVC.Models;

namespace TripCompanion_MVC.Interfaces
{
    public interface ITripService
    {
        Task<IEnumerable<Trip>> GetAllTrip();
        Task<IEnumerable<Trip>> GetAllTripByUser(int userId);
        Task<Trip> GetTripById(int id);

    }
}
