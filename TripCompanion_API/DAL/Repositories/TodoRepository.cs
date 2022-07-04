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
    public class TodoRepository : RepositoryBase<int, TodoEntity>, IRepository
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
                IdMainTodo = (int)record["IdMainTodo"],
                Name = (string)record["Name"],
                Done = (bool)record["Done"],
                Status = (string)record["Status"],
                Type = (string)record["Type"],
                Priority = (string)record["Priority"],
                Calendar = (DateTime)record["Calendar"],
                Location = (string)record["Location"],
                PlannedTime = (double)record["PlannedTime"],
                PlannedBudget=(int)record["PlannedBudget"],
                RealTime=(double)record["RealTime"],
                RealBudget=(int)record["RealBudget"],
                Comments=(string)record["Comments"]
                
                
                
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
            cmd.AddParameter("Budget", entity.Budget);
            cmd.AddParameter("Comments", entity.Comments);
            cmd.AddParameter("IdUser", entity.IdUser);
            
            return (int)_Connection.ExecuteScalar(cmd);
        }

        public override bool Update(int id, TodoEntity entity)
        {
            CommandSP cmd = new CommandSP($"Update{TableName}");

            cmd.AddParameter("IdTodo", id);
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("StartingDate", entity.StartingDate);
            cmd.AddParameter("EndingDate", entity.EndingDate);
            cmd.AddParameter("Budget", entity.Budget);
            cmd.AddParameter("Comments", entity.Comments);
            cmd.AddParameter("IdUser", entity.IdUser);

            return (int)_Connection.ExecuteScalar(cmd) == 1;
        }
        public virtual TodoEntity GetByTodoname(string Todoname)
        {
            CommandSP cmd = new CommandSP($"Get{TableName}ByTodoname");
            cmd.AddParameter("Todoname", Todoname);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }
    }
}
