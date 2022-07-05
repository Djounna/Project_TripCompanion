using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections;
using Tools.DBConnections;

namespace DAL.Repositories
{
    public class UserRepository : RepositoryBase<int, UserEntity>, IUserRepository
    {

        #region Ctor
        public UserRepository(Connection connection): base(connection, "User", "IdUser")
        {

        }
        #endregion

        #region Mapper
        protected override UserEntity MapRecordToEntity(IDataRecord record)
        {
            return new UserEntity()
            {
                IdUser = (int)record[TableId],
                Username = (string)record["Username"],
                Email = (string)record["Email"],
                Password = null
            };
        }
        #endregion

        #region CRUD
        public override int Insert(UserEntity entity)
        {
            CommandSP cmd = new CommandSP($"Create{TableName}");

            cmd.AddParameter("Username", entity.Username);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("Password", entity.Password);

            return (int)_Connection.ExecuteScalar(cmd);
        }
        public override bool Update(int id, UserEntity entity)
        {
            CommandSP cmd = new CommandSP($"Update{TableName}");

            cmd.AddParameter("IdUser", id);
            cmd.AddParameter("Username", entity.Username);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("Password", entity.Password);

            return (int)_Connection.ExecuteScalar(cmd) == 1;
        }

        public string? GetPasswordHash(string username) // A voir
        {
            CommandSP cmd = new CommandSP($"Get{TableName}PasswordHashByUsername");
            cmd.AddParameter("Username", username);

            return _Connection.ExecuteScalar(cmd)?.ToString();
        }
        public virtual UserEntity GetByUsername(string username)
        {
            CommandSP cmd = new CommandSP($"Get{TableName}ByUsername");
            cmd.AddParameter("Username", username);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }
        #endregion
        public bool CheckUserExists(string username, string email)
        {
            CommandSP cmd = new CommandSP($"Check{TableName}Exists");
            cmd.AddParameter("Username", username);
            cmd.AddParameter("Email", email);

            return ((int)_Connection.ExecuteScalar(cmd)) == 1;
        }
    }
}
