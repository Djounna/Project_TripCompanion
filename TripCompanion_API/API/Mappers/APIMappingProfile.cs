using API.Models.APIApiModels;
using AutoMapper;
using BLL.DTO.APIDtos;

namespace API.Mappers
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<WeatherDTO, WeatherApiModel>();
            CreateMap<LocalizationDTO, LocalizationApiModel>();
        }
    }
}
