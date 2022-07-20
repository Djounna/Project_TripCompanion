using Microsoft.AspNetCore.Mvc;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;

namespace TodoCompanion_MVC.Controllers
{
    public class TodoController : Controller
    {

        private IApiConsume _apiConsume;
        ITodoService _todoService;
        private IStepService _stepService;
        #region Ctor
        public TodoController(ITodoService todoService, IApiConsume apiConsume)
        {
            _apiConsume = apiConsume;       
            _todoService = todoService;
        }
        #endregion

        #region Crud
        public async Task<IActionResult> AllTodos()
        {
            IEnumerable<Todo> listTodo = await _todoService.GetAllTodo();
            return View(listTodo);
        }

        public async Task<IActionResult> AllTodosByStep(int idStep)
        {
            IEnumerable<Todo> listTodo = await _todoService.GetAllTodoByStep(idStep);
            return View(listTodo);
        }

        public async Task<IActionResult> TodoById(int id)
        {
            Todo Todo = await _apiConsume.GetOne<Todo>("Todo/GetTodoById/" + id);
            return View(Todo);
        }
        #endregion
    }
}
