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
        private IStepRepository stepRepository;
        private StepService stepService;

        public TripService(ITripRepository tripRepository, IStepRepository stepRepository, StepService stepService)
        {
            this.tripRepository = tripRepository;
            this.stepRepository = stepRepository;
            this.stepService = stepService;
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
            DeleteAllStepByTrip(id); // Test en cours
            return tripRepository.Delete(id);
        }

        // Test en cours
        public void DeleteAllStepByTrip(int id)
        {
            IEnumerable<StepDTO> listStep = stepRepository.GetAllStepByTrip(id).Select(b => b.ToDTO());
            foreach (StepDTO step in listStep)
            {
                stepService.Delete(step.IdStep);
            }
        }
    }
}
