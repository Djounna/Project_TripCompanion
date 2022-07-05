using BLL.DTO;
using BLL.Mappers;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository repo)
        {
            this.userRepository = repo;
        }
        public IEnumerable<UserDTO> GetAll()
        {
            return userRepository.GetAll().Select(b => b.ToDTO());
        }
        public UserDTO GetByName(string name) // A tester
        {
            return userRepository.GetByUsername(name).ToDTO();
        }
        public bool Insert(UserDTO user)
        {
            return userRepository.Insert(user.ToEntity()) > 0;
        }
        public bool Update(UserDTO user)
        {
            return userRepository.Update(user.IdUser, user.ToEntity());
        }
        public bool Delete(int id)
        {
            return userRepository.Delete(id);
        }


    }
}
