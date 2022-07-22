using TripCompanion_MVC.Models;

namespace TripCompanion_MVC.Interfaces
{
    public interface IStepService
    {
        Task<IEnumerable<Step>> GetAllStep();
        Task<IEnumerable<Step>> GetAllStepByTrip(int idTrip);
        Task<Step> GetStepById(int idStep);


        Task DeleteStep(int id);
        Task UpdateStep(Step step);
        Task<Step> CreateStep(StepForm stepForm);

    }
}
