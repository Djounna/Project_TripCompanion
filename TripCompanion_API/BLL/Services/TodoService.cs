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
    public class TodoService
    {
        private ITodoRepository todoRepository;

        public TodoService(ITodoRepository repo)
        {
            this.todoRepository = repo;
        }

        public IEnumerable<TodoDTO> GetAll()
        {
            return todoRepository.GetAll().Select(b => b.ToDTO());
        }

        public TodoDTO GetByName(string name) // A Tester
        {
            return todoRepository.GetByTodoname(name).ToDTO();
        }

        public bool Insert(TodoDTO todo)
        {
            return todoRepository.Insert(todo.ToEntity()) > 0;
        }

        public bool Update(TodoDTO todo)
        {
            return todoRepository.Update(todo.IdTodo, todo.ToEntity());
        }

        public bool Delete(int id)
        {
            return todoRepository.Delete(id);
        }
    }
}
