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
            Step step = await _apiConsume.GetOne<Step>("Step/GetStepById/" + id, _sessionManager.Token);
            return step;
        }
        public async Task<IEnumerable<Step>> GetAllStep()
        {
            IEnumerable<Step> listStep = await _apiConsume.GetMany<Step>("Step", _sessionManager.Token);
            return listStep;
        }

        public async Task<IEnumerable<Step>> GetAllStepByTrip(int idTrip)
        {
            IEnumerable<Step> listStep = await _apiConsume.GetMany<Step>("Step/GetAllStepByTrip/"+idTrip, _sessionManager.Token);
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

            return await _apiConsume.Post<Step>("Step", stepToPost, _sessionManager.Token);
        }

        public async Task UpdateStep(Step step)
        {
            await _apiConsume.Put("Step", step, _sessionManager.Token);
        }

        public async Task DeleteStep(int id)
        {
            await _apiConsume.Delete<Step>("Step/" + id, _sessionManager.Token);
        }
        #endregion


    }
}
