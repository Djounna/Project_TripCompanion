using BLL.DTO;
using BLL.Mappers;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TripService
    {
        private ITripRepository tripRepository;

        public TripService(ITripRepository repo)
        {
            this.tripRepository = repo;
        }
        public IEnumerable<TripDTO> GetAll()
        {
            return tripRepository.GetAll().Select(b => b.ToDTO());
        }

        public TripDTO GetById(int id)
        {
            return tripRepository.GetById(id).ToDTO();
        }

        public IEnumerable<TripDTO> GetAllTripByUser(int idUser)
        {
            return tripRepository.GetAllTripByUser(idUser).Select(b => b.ToDTO());
        }





        public TripDTO GetByName(string name) // A Tester
        {
            return tripRepository.GetByTripname(name).ToDTO();
        }
        public bool Insert(TripDTO trip)
        {
            return tripRepository.Insert(trip.ToEntity()) > 0;
        }
        public bool Update(TripDTO trip)
        {
            return tripRepository.Update(trip.IdTrip, trip.ToEntity());
        }
        public bool Delete(int id)
        {
            return tripRepository.Delete(id);
        }
    }
}
