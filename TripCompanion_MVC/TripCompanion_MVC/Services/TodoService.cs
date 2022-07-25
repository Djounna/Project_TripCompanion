using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;

namespace TripCompanion_MVC.Services
{
    public class TodoService : ITodoService
    {

        private IApiConsume _apiConsume;
        private readonly SessionManager _sessionManager;
        #region Ctor
        public TodoService(IApiConsume apiConsume, SessionManager sessionManager)
        {
            _apiConsume = apiConsume;
            _sessionManager = sessionManager;
        }
        #endregion
        public async Task<Todo> GetTodoById(int id)
        {
            Todo todo = await _apiConsume.GetOne<Todo>("Todo/GetTodoById/" + id, _sessionManager.Token);
            return todo;
        }
        public async Task<IEnumerable<Todo>> GetAllTodo()
        {
            IEnumerable<Todo> listTodo = await _apiConsume.GetMany<Todo>("Todo", _sessionManager.Token);
            return listTodo;
        }
        public async Task<IEnumerable<Todo>> GetAllTodoByStep(int idStep)
        {
            IEnumerable<Todo> listTodo = await _apiConsume.GetMany<Todo>("Todo/GetAllTodoByStep/" + idStep, _sessionManager.Token);
            return listTodo;
        }

        #region CRUD
        public async Task<Todo> CreateTodo(TodoForm todoForm)
        {
            Todo todoToPost = new Todo
            {
                IdTodo = 0,
                Name = todoForm.Name,
                Calendar = todoForm.Calendar,
                Priority = todoForm.Priority,
                Done = todoForm.Done,
                Status = todoForm.Status,
                Location = todoForm.Location,
                Type = todoForm.Type,
                PlannedBudget = todoForm.PlannedBudget,
                PlannedTime = todoForm.PlannedTime,
                RealBudget = todoForm.RealBudget,
                RealTime = todoForm.RealTime,
                Comments = todoForm.Comments,
                IdMainTodo = todoForm.IdMainTodo,            
                IdStep = todoForm.IdStep
            };

            return await _apiConsume.Post<Todo>("Todo", todoToPost, _sessionManager.Token);
        }

        public async Task UpdateTodo(Todo todo)
        {
            await _apiConsume.Put<Todo>("Todo", todo, _sessionManager.Token);
        }

        public async Task DeleteTodo(int id)
        {
            await _apiConsume.Delete<Todo>("Todo/Delete/" + id, _sessionManager.Token);
        }
        #endregion



    }
}
