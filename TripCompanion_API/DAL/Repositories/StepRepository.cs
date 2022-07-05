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
    public class StepRepository : RepositoryBase<int, StepEntity>, IStepRepository
    {
        #region ctor
        public StepRepository(Connection connection) : base(connection, "Step", "IdStep")
        {
        }
        #endregion

        #region Mapper
        protected override StepEntity MapRecordToEntity(IDataRecord record)
        {
            return new StepEntity()
            {
                Name = (string)record["Name"],
                Budget = record["Budget"] is DBNull ? null : (int)record["Budget"],
                Time = record["Time"] is DBNull ? null : (double)record["Time"],              
                Comments = record["Comments"] is DBNull ? null : (string)record["Comments"]
            };
        }
        #endregion

        #region CRUD
        public override int Insert(StepEntity entity)
        {
            CommandSP cmd = new CommandSP($"Create{TableName}");
          
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Budget", entity.Budget);
            cmd.AddParameter("Time", entity.Time);
            cmd.AddParameter("Comments", entity.Comments);

            return (int)_Connection.ExecuteScalar(cmd);
        }

        public override bool Update(int id, StepEntity entity)
        {
            CommandSP cmd = new CommandSP($"Update{TableName}");

            cmd.AddParameter("IdStep", id);
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Budget", entity.Budget);
            cmd.AddParameter("Time", entity.Time);
            cmd.AddParameter("Comments", entity.Comments);

            return (int)_Connection.ExecuteScalar(cmd) == 1;
        }
        public virtual StepEntity GetByStepname(string name)
        {
            CommandSP cmd = new CommandSP($"Get{TableName}ByStepname");
            cmd.AddParameter("Name", name);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }
        #endregion
    }
}
