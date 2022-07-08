using BLL.DTO;
using BLL.Mappers;
using DAL.Interfaces;
using DAL.Repositories;
using Isopoh.Cryptography.Argon2;
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
        public UserDTO GetByName(string name)
        {
            return userRepository.GetByUsername(name).ToDTO();
        }
        #region Register and Login
        public bool CheckUserExists(string username, string email)
        {
            return userRepository.CheckUserExists(username, email);
        }
        public UserDTO? GetByCredentials(string username, string pwd)
        {
            // Récuperation du hashage du mot de passe
            string? pwdHash = userRepository.GetPasswordHash(username);
            if (pwdHash is null)
            {
                return null;
            }
            // Validation du hashage du mot de passe
            if (!Argon2.Verify(pwdHash, pwd))
            {
                return null;
            }
            return userRepository.GetByUsername(username).ToDTO();
        }
        #endregion
        public UserDTO Insert(UserDTO user)
        {
            //Hashage du Mot de passe
            string pwdHash = Argon2.Hash(user.Password);

            user.Password = pwdHash;

            int id = userRepository.Insert(user.ToEntity());

            return userRepository.GetById(id).ToDTO();
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
