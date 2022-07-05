using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class UserMapper
    {
        public static UserDTO ToDTO(this UserEntity entity)
        {
            return new UserDTO()
            {
                IdUser = entity.IdUser,
                Username = entity.Username,
                Email = entity.Email,
                Password = entity.Password
                
            };
        }

        public static UserEntity ToEntity(this UserDTO dto)
        {
            return new UserEntity()
            {
                IdUser = dto.IdUser,
                Username=dto.Username,
                Email=dto.Email,
                Password=dto.Password
               
            };
        }
    }
}
