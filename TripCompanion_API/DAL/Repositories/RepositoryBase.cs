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
    public abstract class RepositoryBase<TKey, TEntity> : IRepository<TKey, TEntity>
    {
        protected Connection _Connection { get; set; }
        protected string TableName { get; set; }
        protected string TableId { get; set; }

        public RepositoryBase(Connection connection, string tableName, string tableId)
        {
            _Connection = connection;
            TableName = tableName;
            TableId = tableId;
        }

        protected abstract TEntity MapRecordToEntity(IDataRecord record);

        public virtual IEnumerable<TEntity> GetAll()
        {
            CommandSP cmd = new CommandSP($"GetAll{TableName}");

            return _Connection.ExecuteReader(cmd, MapRecordToEntity);
        }

        public virtual TEntity GetById(TKey id)
        {
            CommandSP cmd = new CommandSP($"Get{TableName}ById");
            cmd.AddParameter("Id", id);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }

        public abstract TKey Insert(TEntity entity);

        public abstract bool Update(TKey id, TEntity entity);

        public virtual bool Delete(TKey id)
        {
            CommandSP cmd = new CommandSP($"Delete{TableName}");
            cmd.AddParameter("Id", id);

            return _Connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
