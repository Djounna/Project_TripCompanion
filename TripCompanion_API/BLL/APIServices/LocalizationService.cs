using AutoMapper;
using BLL.DTO.APIDtos;
using DAL.ApiRepos;
using DAL.Entities.APIEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.APIServices
{
    public class LocalizationService
    {
        private readonly IMapper _mapper;
        private readonly GeoapifyAPI _geoapifgyAPI;

        public LocalizationService(IMapper mapper, GeoapifyAPI geoapifgyAPI)
        {
            _mapper = mapper;
            _geoapifgyAPI = geoapifgyAPI;
        }

        public async Task<LocalizationDTO> SearchLocation(string query)
        {            
            return _mapper.Map<LocalizationDTO>(await _geoapifgyAPI.Search(query));
        }

    }
}
