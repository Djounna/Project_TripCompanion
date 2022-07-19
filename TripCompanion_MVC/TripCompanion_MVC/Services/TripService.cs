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
            Trip trip = await _apiConsume.GetOne<Trip>("Trip/GetTripById" + id);
            return trip;
        }
    }
}
