using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;

namespace TripCompanion_MVC.Services
{
    public class TripService : ITripService
    {
        private IApiConsume _apiConsume;
        private readonly SessionManager _sessionManager;
        #region Ctor
        public TripService(IApiConsume apiConsume, SessionManager sessionManager)
        {
            _apiConsume = apiConsume;
            _sessionManager = sessionManager;
        }
        #endregion

        public async Task<IEnumerable<Trip>> GetAllTrip()
        {
            IEnumerable<Trip> listTrip = await _apiConsume.GetMany<Trip>("Trip", _sessionManager.Token);
            return listTrip;
        }

        public async Task<IEnumerable<Trip>> GetAllTripByUser(int idUser)
        {
            IEnumerable<Trip> listTrip = await _apiConsume.GetMany<Trip>("Trip/GetAllTripByUser/" + idUser, _sessionManager.Token);
            return listTrip;
        }
        public async Task<Trip> GetTripById(int id)
        {
            Trip trip = await _apiConsume.GetOne<Trip>("Trip/GetTripById/" + id, _sessionManager.Token);
            return trip;
        }


        #region CRUD
        public async Task<Trip> CreateTrip(TripForm tripForm)
        {
            Trip tripToPost = new Trip
            {
                IdTrip = 0,
                Name = tripForm.Name,
                Budget = tripForm.Budget,
                Comments = tripForm.Comments,
                StartingDate = tripForm.StartingDate,
                EndingDate = tripForm.EndingDate,
                IdUser = (int)_sessionManager.IdUser               
            };

            return await _apiConsume.Post<Trip>("Trip", tripToPost, _sessionManager.Token);
        }
            
        public async Task UpdateTrip(Trip trip)
        {         
            await _apiConsume.Put("Trip", trip, _sessionManager.Token);
        }

        public async Task DeleteTrip(int id)
        {
            await _apiConsume.Delete<Trip>("Trip/Delete/"+ id, _sessionManager.Token);
        }
        #endregion
    }
}
