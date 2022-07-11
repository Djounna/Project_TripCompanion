using Microsoft.AspNetCore.Mvc;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;

namespace TodoCompanion_MVC.Controllers
{
    public class TodoController : Controller
    {

        private IApiConsume _apiConsume;
        #region Ctor
        public TodoController(IApiConsume apiConsume)
        {
            _apiConsume = apiConsume;
        }
        #endregion

        #region Crud
        public async Task<IActionResult> AllTodos()
        {
            IEnumerable<Todo> listTodo = await _apiConsume.GetMany<Todo>("Todo");
            return View(listTodo);
        }
        public async Task<IActionResult> TodoById(int id)
        {
            Todo Todo = await _apiConsume.GetOne<Todo>("Todo/GetTodoById" + id);
            return View(Todo);
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}
