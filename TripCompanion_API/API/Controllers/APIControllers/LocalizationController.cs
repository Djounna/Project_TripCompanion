using AutoMapper;
using BLL.APIServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly LocalizationService _localizationService;

        public LocalizationController(IMapper mapper, LocalizationService localizationService)
        {
            _mapper = mapper;
            _localizationService = localizationService;
        }
    }
}
