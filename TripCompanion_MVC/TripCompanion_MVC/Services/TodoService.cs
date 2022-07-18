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
            Todo todo = await _apiConsume.GetOne<Todo>("Todo/GetTodoById" + id);
            return todo;
        }
        public async Task<IEnumerable<Todo>> GetAllTodo()
        {
            IEnumerable<Todo> listTodo = await _apiConsume.GetMany<Todo>("Todo");
            return listTodo;
        }

        public async Task<IEnumerable<Todo>> GetAllTodoByStep(int idStep)
        {
            IEnumerable<Todo> listTodo = await _apiConsume.GetMany<Todo>("Todo/GetAllTodoByStep" + idStep);
            return listTodo;
        }

        
        



    }
}
