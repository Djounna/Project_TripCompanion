using API.Models;
using BLL.DTO;

namespace API.Mappers
{
    public static class StepApiMapper
    {
        public static StepApiModel ToApi(this StepDTO step)
        {
            return new StepApiModel()
            {
                IdStep = step.IdStep,
                Name = step.Name,
                Budget = step.Budget,
                Time = step.Time,
                Comments = step.Comments,
                IdTrip = step.IdTrip            

            };
        }
        public static StepDTO ToDto(this StepApiModel step)
        {
            return new StepDTO()
            {
                IdStep = step.IdStep,
                Name = step.Name,
                Budget = step.Budget,
                Time = step.Time,
                Comments = step.Comments,
                IdTrip = step.IdTrip
            };
        }
    }
}
