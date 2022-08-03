using API.Models.APIApiModels;
using AutoMapper;
using BLL.APIServices;
using BLL.DTO.APIDtos;
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

        [HttpGet]
        public async Task<ActionResult> SearchLocation(string query)
        {
            LocalizationDTO loc = await _localizationService.SearchLocation(query);
            return Ok(_mapper.Map<LocalizationApiModel>(loc));
        }
    }
}
