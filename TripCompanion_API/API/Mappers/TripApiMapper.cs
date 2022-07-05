using API.Models;
using BLL.DTO;

namespace API.Mappers
{
    public static class TripApiMapper
    {
        public static TripApiModel ToApi(this TripDTO trip)
        {
            return new TripApiModel()
            {
                IdTrip = trip.IdTrip,
                Name = trip.Name,
                StartingDate = trip.StartingDate,
                EndingDate = trip.EndingDate,
                Budget = trip.Budget,
                Comments = trip.Comments,
                IdUser = trip.IdUser
                
            };
        }
        public static TripDTO ToDto(this TripApiModel trip)
        {
            return new TripDTO()
            {
                IdTrip = trip.IdTrip,
                Name = trip.Name,
                StartingDate = trip.StartingDate,
                EndingDate = trip.EndingDate,
                Budget = trip.Budget,
                Comments = trip.Comments,
                IdUser = trip.IdUser
            };
        }
    }
}
