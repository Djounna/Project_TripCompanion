using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class TodoMapper
    {
        public static TodoDTO ToDTO(this TodoEntity entity)
        {
            return new TodoDTO()
            {
                IdTodo = entity.IdTodo,
                IdStep = entity.IdStep,
                IdMainTodo = entity.IdMainTodo,
                Name = entity.Name,
                Done = entity.Done,
                Status = entity.Status,
                Type = entity.Type,
                Priority = entity.Priority,
                Calendar = entity.Calendar,
                Location = entity.Location,
                PlannedTime = entity.PlannedTime,
                PlannedBudget = entity.PlannedBudget,
                RealTime = entity.RealTime,
                RealBudget = entity.RealBudget,
                Comments = entity.Comments,
                
            };
        }

        public static TodoEntity ToEntity(this TodoDTO dto)
        {
            return new TodoEntity()
            {
                IdTodo = dto.IdTodo,
                Name = dto.Name,
                Done= dto.Done,
                Status= dto.Status,
                Type= dto.Type,
                Priority= dto.Priority,
                Calendar= dto.Calendar,
                Location= dto.Location,
                PlannedTime= dto.PlannedTime,
                PlannedBudget= dto.PlannedBudget,
                RealTime= dto.RealTime,
                RealBudget= dto.RealBudget,
                Comments= dto.Comments,
                IdStep= dto.IdStep,
                IdMainTodo= dto.IdMainTodo
            };
        }
    }
}
