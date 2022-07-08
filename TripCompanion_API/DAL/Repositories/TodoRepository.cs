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
    public class TodoRepository : RepositoryBase<int, TodoEntity>, ITodoRepository
    {
         #region ctor
        public TodoRepository(Connection connection) : base(connection, "Todo", "IdTodo")
        {
        }
        #endregion

        #region Mapper
        protected override TodoEntity MapRecordToEntity(IDataRecord record)
        {
            return new TodoEntity()
            {
                IdTodo = (int)record[TableId],
                IdStep = (int)record["IdStep"],
                IdMainTodo = record["IdMainTodo"] is DBNull ? null: (int)record["IdMainTodo"],
                Name = (string)record["Name"],
                Done = (bool)record["Done"],
                Status = (string)record["Status"],
                Type = record["Type"] is DBNull ? null : (string)record["Type"],
                Priority = record["Priority"] is DBNull ? null : (string)record["Priority"],
                Calendar = record["Calendar"] is DBNull ? null : (DateTime)record["Calendar"],
                Location = record["Location"] is DBNull ? null : (string)record["Location"],
                PlannedTime = record["PlannedTime"] is DBNull ? null : (double)record["PlannedTime"],
                PlannedBudget= record["PlannedBudget"] is DBNull ? null : (int)record["PlannedBudget"],
                RealTime= record["RealTime"] is DBNull ? null : (double)record["RealTime"],
                RealBudget= record["RealBudget"] is DBNull ? null : (int)record["RealBudget"],
                Comments= record["Comments"] is DBNull ? null : (string)record["Comments"]                                
            };
        }
        #endregion

        #region CRUD
        public override int Insert(TodoEntity entity)
        {
            CommandSP cmd = new CommandSP($"Create{TableName}");
           
            cmd.AddParameter("IdStep", entity.IdStep);
            cmd.AddParameter("IdMainTodo", entity.IdMainTodo);

            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Done", entity.Done);
            cmd.AddParameter("Status", entity.Status);
            cmd.AddParameter("Type", entity.Type);
            cmd.AddParameter("Priority", entity.Priority); 
            cmd.AddParameter("Calendar", entity.Calendar);
            cmd.AddParameter("Location", entity.Location);
            cmd.AddParameter("PlannedTime", entity.PlannedTime);
            cmd.AddParameter("PlannedBudget", entity.PlannedBudget);          
            cmd.AddParameter("Comments", entity.Comments);

            return (int)_Connection.ExecuteScalar(cmd);
        }

        public override bool Update(int id, TodoEntity entity)
        {
            CommandSP cmd = new CommandSP($"Update{TableName}");

            cmd.AddParameter("IdTodo", id);

            cmd.AddParameter("IdStep", entity.IdStep);
            cmd.AddParameter("IdMainTodo", entity.IdMainTodo);

            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Done", entity.Done);
            cmd.AddParameter("Status", entity.Status);
            cmd.AddParameter("Type", entity.Type);
            cmd.AddParameter("Priority", entity.Priority);
            cmd.AddParameter("Calendar", entity.Calendar);
            cmd.AddParameter("Location", entity.Location);
            cmd.AddParameter("PlannedTime", entity.PlannedTime);
            cmd.AddParameter("PlannedBudget", entity.PlannedBudget);
            cmd.AddParameter("RealTime", entity.RealTime);
            cmd.AddParameter("RealBudget", entity.RealBudget);
            cmd.AddParameter("Comments", entity.Comments);

            return (int)_Connection.ExecuteScalar(cmd) == 1;
        }
        public virtual TodoEntity GetByTodoname(string name)
        {
            CommandSP cmd = new CommandSP($"Get{TableName}ByTodoname");
            cmd.AddParameter("Name", name);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }
        #endregion
    }
}
