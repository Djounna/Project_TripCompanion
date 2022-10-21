using DAL_EF.Entities;

namespace DAL_EF.DataAccess
{
    public interface IUserDataAccess
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        bool Insert(User user);
        bool Update(int id,User user);
    }
}