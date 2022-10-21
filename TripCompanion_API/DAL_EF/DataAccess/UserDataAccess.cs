using DAL_EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EF.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly TripCompanionContext _context;

        public UserDataAccess(TripCompanionContext context)
        {
            _context = context;
        }

        public User GetById(int id)
        {
            User? user = _context.Users.Where(u => u.IdUser == id).FirstOrDefault();
            if (user == null)
                return null;
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users = _context.Users.ToList();
            return users;
        }

        public bool Insert(User user)
        {
            _context.Users.Add(user);
            return (_context.SaveChanges() > 0);
        }

        public bool Update(int id, User user)
        {
            var userToUpdate = _context.Users.Where(u => u.IdUser == id).FirstOrDefault();
            if (userToUpdate == null)
            {
                return false;
            }

            userToUpdate.Username = user.Username;
            userToUpdate.Email = user.Email;
            
            return _context.SaveChanges() > 0;
        }

    }
}
