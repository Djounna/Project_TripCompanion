using API.Models;
using BLL.DTO;

namespace API.Mappers
{
    public static class TodoApiMapper
    {
        public static TodoApiModel ToApi(this TodoDTO step)
        {
            return new TodoApiModel()
            {
                IdTodo = step.IdTodo,
                Name = step.Name,
                Done = step.Done,
                Status = step.Status,
                Type = step.Type,
                Priority = step.Priority,
                Calendar = step.Calendar,
                Location = step.Location,
                PlannedTime = step.PlannedTime,
                PlannedBudget = step.PlannedBudget,
                RealTime = step.RealTime,
                RealBudget = step.RealBudget,
                Comments = step.Comments,
                IdStep = step.IdStep,
                IdMainTodo = step.IdMainTodo
            };
        }
        public static TodoDTO ToDto(this TodoApiModel step)
        {
            return new TodoDTO()
            {
                IdTodo = step.IdTodo,
                Name = step.Name,
                Done = step.Done,
                Status = step.Status,
                Type = step.Type,
                Priority = step.Priority,
                Calendar = step.Calendar,
                Location = step.Location,
                PlannedTime = step.PlannedTime,
                PlannedBudget = step.PlannedBudget,
                RealTime = step.RealTime,
                RealBudget = step.RealBudget,
                Comments = step.Comments,
                IdStep = step.IdStep,
                IdMainTodo = step.IdMainTodo
            };
        }
    }
}
