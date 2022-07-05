using API.Models;
using BLL.DTO;

namespace API.Mappers
{
    public static class UserApiMapper
    {
        public static UserApiModel ToApi(this UserDTO user)
        {
            return new UserApiModel()
            {
                IdUser = user.IdUser,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password
            };
        }
        public static UserDTO ToDto(this UserApiModel user)
        {
            return new UserDTO()
            {
                IdUser = user.IdUser,
                Username=user.Username,
                Email=user.Email,
                Password=user.Password
            };
        }
    }
}
