using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITodoRepository : IRepository<int, TodoEntity>
    {
        IEnumerable<TodoEntity> GetAllTodoByStep(int idStep);
        TodoEntity GetByTodoname(string name);
    }
}
