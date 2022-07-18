using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITripRepository : IRepository<int, TripEntity>
    {
        IEnumerable<TripEntity> GetAllTripByUser(int idUser);
        TripEntity GetByTripname(string Tripname);
        
    }
}
