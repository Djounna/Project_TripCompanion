using TripCompanion_MVC.Models;

namespace TripCompanion_MVC.Interfaces
{
    public interface IStepService
    {
        Task<IEnumerable<Step>> GetAllStepByTrip(int idTrip);
    }
}
