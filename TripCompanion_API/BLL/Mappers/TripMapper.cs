using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class TripMapper
    {
        public static TripDTO ToDTO(this TripEntity entity)
        {
            return new TripDTO()
            {
                IdTrip = entity.IdTrip,
                Name = entity.Name,
                StartingDate = entity.StartingDate,
                EndingDate = entity.EndingDate,
                Budget = entity.Budget,
                Comments = entity.Comments,
                IdUser = entity.IdUser,
            };
        }

        public static TripEntity ToEntity(this TripDTO dto)
        {
            return new TripEntity()
            {
                IdTrip = dto.IdTrip,
                Name = dto.Name,
                StartingDate= dto.StartingDate,
                EndingDate= dto.EndingDate,
                Budget= dto.Budget,
                Comments= dto.Comments,
                IdUser= dto.IdUser,            
            };
        }
    }
}
