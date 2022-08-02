using AutoMapper;
using BLL.DTO.APIDtos;
using DAL.ApiRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.APIServices
{
    public class WeatherService
    {
        private readonly IMapper _mapper;
        private readonly OpenWeatherMapAPI _openWeatherMapApi;

        public WeatherService(IMapper mapper, OpenWeatherMapAPI openWeatherMapApi)
        {
            _mapper = mapper;
            _openWeatherMapApi = openWeatherMapApi;
        }

        public async Task<WeatherDTO> GetWeatherForLocation(string lat, string lon)
        {
            return _mapper.Map<WeatherDTO>(await _openWeatherMapApi.Search(lat, lon));
        }
    }
}
