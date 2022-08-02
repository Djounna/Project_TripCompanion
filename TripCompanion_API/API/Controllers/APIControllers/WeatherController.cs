using AutoMapper;
using BLL.APIServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly WeatherService _weatherService;

        public WeatherController(IMapper mapper, WeatherService weatherService)
        {
            _mapper = mapper;
            _weatherService = weatherService;
        }
    }
}
