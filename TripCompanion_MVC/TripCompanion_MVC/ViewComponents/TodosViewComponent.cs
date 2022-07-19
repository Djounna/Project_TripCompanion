using Microsoft.AspNetCore.Mvc;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;
using TripCompanion_MVC.Services;

namespace TripCompanion_MVC.ViewComponents
{
    [ViewComponent(Name = "Todos")]
    public class TodosViewComponent : ViewComponent
    {
        private ITodoService _todoService;
        private SessionManager _sessionManager;
        #region Ctor
        public TodosViewComponent(ITodoService todoService, SessionManager sessionManager)
        {
            _todoService = todoService;
            _sessionManager = sessionManager;
        }
        #endregion

        public async Task<IViewComponentResult> InvokeAsync(int idStep)
        {
            if (_sessionManager.IdUser == 0)
            {
                TempData["ErrorMessageVCTodos"] = "Error : vous n'êtes pas identifié";
                return View();
            }
            IEnumerable<Todo> listTodo = await _todoService.GetAllTodoByStep(idStep);
            return View(listTodo);
        }


    }
}
