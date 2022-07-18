using TripCompanion_MVC.Models;

namespace TripCompanion_MVC.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllTodo();
        Task<IEnumerable<Todo>> GetAllTodoByStep(int idStep);
    }
}
