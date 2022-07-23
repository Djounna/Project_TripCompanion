using Microsoft.AspNetCore.Mvc;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;

namespace TodoCompanion_MVC.Controllers
{
    public class TodoController : Controller
    {

        private ITodoService _todoService;
        
        #region Ctor
        public TodoController(ITodoService todoService)
        {       
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
            Todo Todo = await _todoService.GetTodoById(id);
            return View(Todo);
        }
        #endregion


        #region Create
        public IActionResult Create(int idStep)
        {
            TodoForm todoForm = new TodoForm();
            todoForm.IdStep = idStep;
            return View(todoForm);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] TodoForm todoForm)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Warning : Erreur dans le formualaire";
                return View(todoForm);
            }

            await _todoService.CreateTodo(todoForm);
            TempData["Message"] = "Success : Votre voyage a été ajouté avec succès";
            return RedirectToAction("TravelPage", "Travel");
        }
        #endregion

        #region Update
        public async Task<IActionResult> Edit(int idTodo)
        {
            Todo Todo = await _todoService.GetTodoById(idTodo);
            return View(Todo);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Warning : Erreur dans le formulaire ";
                return View(todo);
            }
            await _todoService.UpdateTodo(todo);
            TempData["Message"] = "Success : Cette Todo a été mise à jour avec succès";
            return RedirectToAction("TravelPage", "Travel");

        }
        #endregion
        #region Delete
        //public async Task<IActionResult> Delete(int idTodo)
        //{
        //    Todo Todo = await _todoService.GetTodoById(idTodo);
        //    return View(Todo);
        //}
        [HttpPost]
        public async Task<IActionResult> Delete(int idTodo)
        {
            await _todoService.DeleteTodo(idTodo);
            TempData["Message"] = "Success : Cette a bien été supprimée";
            return RedirectToAction("TravelPage", "Travel");
        }
        #endregion


    }
}
