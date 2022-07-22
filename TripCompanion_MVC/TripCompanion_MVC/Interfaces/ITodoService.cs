using TripCompanion_MVC.Models;

namespace TripCompanion_MVC.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllTodo();
        Task<IEnumerable<Todo>> GetAllTodoByStep(int idStep);
        Task<Todo> GetTodoById(int idTodo);

        Task DeleteTodo(int id);
        Task UpdateTodo(Todo todo);
        Task<Trip> CreateTodo(TodoForm todoForm);
    }
}
