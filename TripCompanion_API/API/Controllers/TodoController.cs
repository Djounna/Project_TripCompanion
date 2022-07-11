using API.Mappers;
using API.Models;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        private TodoService todoService;
        public TodoController(TodoService todoService)
        {
            this.todoService = todoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(todoService.GetAll().Select(t => t.ToApi()));
        }
        [HttpGet]
        [Route("{Todoname}")]
        public IActionResult GetByName(string Todoname)
        {
            return Ok(todoService.GetByName(Todoname).ToApi());
        }
        [HttpPost]
        public IActionResult AddTodo(TodoApiModel Todo)
        {
            if (todoService.Insert(Todo.ToDto()))
            {
                return Ok(Todo);
            }
            else
            {
                return new BadRequestObjectResult(Todo); // return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult UpdateTodo(TodoApiModel Todo)
        {
            if (todoService.Update(Todo.ToDto()))
            {
                return Ok(Todo);
            }
            else
            {
                return new BadRequestObjectResult(Todo);  //return BadRequest();
            }
        }

        [HttpDelete]

        public IActionResult DeleteTodo(int id)
        {
            if (todoService.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }


    }
}
