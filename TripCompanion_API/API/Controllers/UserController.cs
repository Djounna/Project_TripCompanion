using API.Mappers;
using API.Models;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tools.JWT;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private UserService userService;
        private JwtService jwtService;
        public UserController(UserService userService, JwtService jwtService)
        {
            this.userService = userService;
            this.jwtService = jwtService;

        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(userService.GetAll().Select(u => u.ToApi()));
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(userService.GetById(id).ToApi());
        }

        [HttpGet]
        [Route("GetByName/{username}")]
        public IActionResult GetByName(string username)
        {
            return Ok(userService.GetByName(username).ToApi());
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("{username}/{password}")]
        public IActionResult GetCredentials(string username, string password)
        {
            UserApiModel? user = userService.GetByCredentials(username, password).ToApi();

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest(); 
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Login/{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            UserApiModel? user = userService.GetByCredentials(username, password)?.ToApi();

            if (user != null)
            {
                string token = jwtService.CreateToken("user", username);

                ConnectedUser connectedUser = new ConnectedUser()
                {
                    IdUser = user.IdUser,
                    Email = user.Email,
                    Username = user.Username,
                    Role = "user"
                };
                connectedUser.Token = token;

                return Ok(connectedUser);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]      
        [AllowAnonymous]
        public IActionResult AddUser(UserApiModel user)
        {
            UserApiModel? receivedUser = userService.Insert(user.ToDto()).ToApi();

            if (receivedUser != null)
            {
                return Ok(receivedUser);
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

        // For Test Purposes
        [HttpGet]
        [Route("Nominatim")]
        [AllowAnonymous]
        public async Task<IActionResult> Test()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://nominatim.openstreetmap.org/search?q=namur&format=jsonv2");
            var content = await response.Content.ReadAsStringAsync();
            return Ok(content);
        }


    }
}
