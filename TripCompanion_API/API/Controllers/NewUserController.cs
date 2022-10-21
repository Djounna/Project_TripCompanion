using API.Models;
using AutoMapper;
using BLL.Services;
using DAL_EF.DataAccess;
using DAL_EF.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tools.JWT;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class NewUserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUserDataAccess _userDataAccess;
        private JwtService _jwtService;

        public NewUserController(IUserDataAccess userDataAccess, JwtService jwtService, IMapper mapper)
        {
            _userDataAccess = userDataAccess;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userDataAccess.GetAll();
            return Ok(_mapper.Map<IEnumerable<UserApiModel>>(users)) ;
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userDataAccess.GetById(id);
            return Ok(_mapper.Map<UserApiModel>(user));
        }

        [HttpPost]
        public IActionResult Create(UserApiModel user)
        {
            return Ok(_userDataAccess.Insert(_mapper.Map<User>(user)));
        }

        [HttpPut]
        public IActionResult Update(int id, UserApiModel user)
        {
            return Ok(_userDataAccess.Update(id, _mapper.Map<User>(user)));
        }

    }
}
