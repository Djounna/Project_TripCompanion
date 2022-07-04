using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository : IRepository<int, UserEntity>
    {
        bool CheckUserExists(string username, string email);

        string GetPasswordHash(string username);

        UserEntity GetByUsername(string username);


    }
}
