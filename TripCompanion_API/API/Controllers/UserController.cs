using API.Mappers;
using API.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService userService;
        public UserController(UserService userService)
        {
            this.userService = userService;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(userService.GetAll().Select(u => u.ToApi()));
        }
        [HttpGet]
        [Route("/{username}")]
        public IActionResult GetByName(string username)
        {
            return Ok(userService.GetByName(username).ToApi());
        }
        [HttpPost]      
        public IActionResult AddUser(UserApiModel user)
        {
            if (userService.Insert(user.ToDto()))
            {
                return Ok(user);
            }
            else
            {
                return new BadRequestObjectResult(user); // return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult UpdateUser(UserApiModel user)
        {
            if (userService.Update(user.ToDto()))
            {
                return Ok(user);
            }
            else
            {
                return new BadRequestObjectResult(user);  //return BadRequest();
            }
        }

        [HttpDelete]

        public IActionResult DeleteUser(int id)
        {
            if (userService.Delete(id))
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
