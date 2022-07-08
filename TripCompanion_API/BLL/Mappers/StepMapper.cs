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
                IdTrip = entity.IdTrip,
                Name = entity.Name,
                Budget = entity.Budget,
                Time = entity.Time,
                Comments = entity.Comments
                             
            };
        }

        public static StepEntity ToEntity(this StepDTO dto)
        {
            return new StepEntity()
            {
                IdStep = dto.IdStep,
                IdTrip = dto.IdTrip,
                Name = dto.Name,
                Budget= dto.Budget,
                Time= dto.Time,
                Comments= dto.Comments
                   
            };
        }

    }
}
