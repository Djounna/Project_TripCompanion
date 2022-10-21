using API.Models;
using API.Models.APIApiModels;
using AutoMapper;
using BLL.DTO.APIDtos;
using DAL_EF.Entities;

namespace API.Mappers
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<WeatherDTO, WeatherApiModel>();
            CreateMap<LocalizationDTO, LocalizationApiModel>();
            CreateMap<User, UserApiModel>().ReverseMap();
        }
    }
}
