using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;

namespace TripCompanion_MVC.Services
{
    public class StepService : IStepService
    {
        private IApiConsume _apiConsume;
        private readonly SessionManager _sessionManager;

        #region Ctor
        public StepService(IApiConsume apiConsume, SessionManager sessionManager)
        {
            _apiConsume = apiConsume;
            _sessionManager = sessionManager;
        }
        #endregion
        public async Task<Step> GetStepById(int id)
        {
            Step step = await _apiConsume.GetOne<Step>("Step/GetStepByTripId/" + id);
            return step;
        }
        public async Task<IEnumerable<Step>> GetAllStep()
        {
            IEnumerable<Step> listStep = await _apiConsume.GetMany<Step>("Step");
            return listStep;
        }

        public async Task<IEnumerable<Step>> GetAllStepByTrip(int idTrip)
        {
            IEnumerable<Step> listStep = await _apiConsume.GetMany<Step>("Step/GetAllStepByTrip/"+idTrip);
            return listStep;
        }

        #region CRUD
        public async Task<Step> CreateStep(StepForm stepForm)
        {
            Step stepToPost = new Step
            {
                IdStep= 0,
                Name = stepForm.Name,
                Budget = stepForm.Budget,
                Comments = stepForm.Comments,
                IdTrip = stepForm.IdTrip
            };

            return await _apiConsume.Post<Step>("Step", stepToPost);
        }

        public async Task UpdateStep(Step step)
        {
            await _apiConsume.Put("Step", step);
        }

        public async Task DeleteStep(int id)
        {
            await _apiConsume.Delete<Step>("Step/" + id);
        }
        #endregion


    }
}
