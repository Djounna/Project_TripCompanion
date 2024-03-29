﻿using DAL.Entities;
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
    public class TripRepository : RepositoryBase<int, TripEntity>, ITripRepository
    {
        #region ctor
        public TripRepository(Connection connection) : base(connection, "Trip", "IdTrip")
        {

        }
        #endregion

        #region Mapper
        protected override TripEntity MapRecordToEntity(IDataRecord record)
        {
            return new TripEntity()
            {
                IdTrip = (int)record[TableId],
                IdUser = (int)record["IdUser"],
                Name = (string)record["Name"],
                StartingDate = (DateTime)record["StartingDate"],
                EndingDate = (DateTime)record["EndingDate"],
                Budget = record["Budget"] is DBNull ? null : (int)record["Budget"],
                Comments = record["Comments"] is DBNull ? null : (string)record["Comments"]
                
                
            };
        }
        #endregion

        #region CRUD
        public override int Insert(TripEntity entity)
        {
            CommandSP cmd = new CommandSP($"Create{TableName}");

            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("StartingDate", entity.StartingDate);
            cmd.AddParameter("EndingDate", entity.EndingDate);
            cmd.AddParameter("Budget", entity.Budget);
            cmd.AddParameter("Comments", entity.Comments);
            cmd.AddParameter("IdUser", entity.IdUser);
            
            return (int)_Connection.ExecuteScalar(cmd);
        }

        public override bool Update(int id, TripEntity entity)
        {
            CommandSP cmd = new CommandSP($"Update{TableName}");

            cmd.AddParameter("IdTrip", id);
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("StartingDate", entity.StartingDate);
            cmd.AddParameter("EndingDate", entity.EndingDate);
            cmd.AddParameter("Budget", entity.Budget);
            cmd.AddParameter("Comments", entity.Comments);
            cmd.AddParameter("IdUser", entity.IdUser);

            return (int)_Connection.ExecuteScalar(cmd) > 0;
        }
        public virtual TripEntity GetByTripname(string Tripname)
        {
            CommandSP cmd = new CommandSP($"Get{TableName}ByTripname");
            cmd.AddParameter("Tripname", Tripname);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }

        public virtual IEnumerable<TripEntity> GetAllTripByUser(int idUser)
        {
            CommandSP cmd = new CommandSP($"GetAll{TableName}ByUser");

            cmd.AddParameter("IdUser", idUser);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity);
        }

        #endregion
    }
}
