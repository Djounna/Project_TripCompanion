using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class StepMapper
    {
        public static StepDTO ToDTO(this StepEntity entity)
        {
            return new StepDTO()
            {
                IdStep = entity.IdStep,
                Name = entity.Name,
                Budget = entity.Budget,
                Time = entity.Time,
                Comments = entity.Comments,
                IdTrip = entity.IdTrip              
            };
        }

        public static StepEntity ToEntity(this StepDTO dto)
        {
            return new StepEntity()
            {
                IdStep = dto.IdStep,
                Name = dto.Name,
                Budget= dto.Budget,
                Time= dto.Time,
                Comments= dto.Comments,
                IdTrip= dto.IdTrip     
            };
        }

    }
}
