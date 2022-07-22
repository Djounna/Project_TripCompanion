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
    public class StepService
    {
        private IStepRepository stepRepository;
        private ITodoRepository todoRepository;
        private TodoService todoService;

        public StepService(IStepRepository stepRepository, ITodoRepository todoRepository, TodoService todoService)
        {
            this.stepRepository = stepRepository;
            this.todoRepository = todoRepository;
            this.todoService = todoService;
        }

        public IEnumerable<StepDTO> GetAll()
        {
            return stepRepository.GetAll().Select(b => b.ToDTO());
        }

        public IEnumerable<StepDTO> GetAllStepByTrip(int idTrip)
        {
            return stepRepository.GetAllStepByTrip(idTrip).Select(b=> b.ToDTO());
        }

        public StepDTO GetById(int id)
        {
            return stepRepository.GetById(id).ToDTO();
        }


        public StepDTO GetByName(string name) // A tester
        {
            return stepRepository.GetByStepname(name).ToDTO();
        }

        public bool Insert(StepDTO Step)
        {
            return stepRepository.Insert(Step.ToEntity()) > 0;
        }

        public bool Update(StepDTO Step)
        {
            return stepRepository.Update(Step.IdStep, Step.ToEntity());
        }

        public bool Delete(int id)
        {
            DeleteAllTodopByStep(id); // Test en cours
            return stepRepository.Delete(id);
        }


        // Test en cours
        public void DeleteAllTodopByStep(int id)
        {
            IEnumerable<TodoDTO> listTodo = todoRepository.GetAllTodoByStep(id).Select(b => b.ToDTO());
            foreach (TodoDTO todo in listTodo)
            {
                todoService.Delete(todo.IdTodo);
            }
        }
    }
}
