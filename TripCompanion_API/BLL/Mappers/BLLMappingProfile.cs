using AutoMapper;
using BLL.DTO.APIDtos;
using DAL.Entities.APIEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class BLLMappingProfile : Profile
    {
        public BLLMappingProfile()
        {
            CreateMap<WeatherEntity, WeatherDTO>();
            CreateMap<LocalizationEntity,LocalizationDTO>();
        }

    }
}
