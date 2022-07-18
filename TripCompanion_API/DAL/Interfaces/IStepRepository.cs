using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStepRepository : IRepository<int, StepEntity>
    {
        IEnumerable<StepEntity> GetAllStepByTrip(int idTrip);
        StepEntity GetByStepname(string name);
    }
}
