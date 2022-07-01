using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.DBConnections;

namespace Tools.Connections
{
    // Toolbox ADO to use with stored procedure (SP).
    /* The toolbox creates the connection, the command (given as a CommandSP object containing a string : the name of the SP in the DB) and the parameters (given through the CommandSP object) */
    public class Connection
    {
        private readonly string _connectionString;

        public Connection(string connectionString)
        {
            _connectionString = connectionString;
            using (SqlConnection sqlConnection = CreateConnection())
            {
                sqlConnection.Open();
            }
        }

        private SqlConnection CreateConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            if (sqlConnection is null)
                throw new InvalidOperationException();
            return sqlConnection;
        }
        private SqlCommand CreateCommand(SqlConnection sqlConnection, CommandSP command)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = command.StoredProcedure;       
            sqlCommand.CommandType = CommandType.StoredProcedure;

            foreach (KeyValuePair<string, object> kvp in command.Parameters)
            {
                SqlParameter sqlParameter = sqlCommand.CreateParameter();
                sqlParameter.ParameterName = kvp.Key;
                sqlParameter.Value = kvp.Value;
                sqlCommand.Parameters.Add(sqlParameter);
            }

            return sqlCommand;
        }


        public object? ExecuteScalar(CommandSP command)
        {
            using (SqlConnection sqlConnection = CreateConnection())
            {
                using (SqlCommand sqlCommand = CreateCommand(sqlConnection, command))
                {
                    try
                    {
                        sqlConnection.Open();
                        object? result = sqlCommand.ExecuteScalar();
                        return result is DBNull ? null : result;
                    }
                    catch (Exception ex)
                    {
                        //log the error
                        return null;
                    }
                }
            }
        }

        public int ExecuteNonQuery(CommandSP command)
        {
            using (SqlConnection sqlConnection = CreateConnection())
            {
                using (SqlCommand sqlCommand = CreateCommand(sqlConnection, command))
                {
                    sqlConnection.Open();
                    return sqlCommand.ExecuteNonQuery();
                }
            }
        }


        public IEnumerable<TResult> ExecuteReader<TResult>(CommandSP command, Func<IDataRecord, TResult> selector)
        {
            using (SqlConnection sqlConnection = CreateConnection())
            {
                using (SqlCommand sqlCommand = CreateCommand(sqlConnection, command))
                {
                    sqlConnection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return selector(reader);
                        }
                    }
                }
            }
        }

        public DataTable GetDataTable(CommandSP command)
        {
            using (SqlConnection sqlConnection = CreateConnection())
            {
                using (SqlCommand sqlCommand = CreateCommand(sqlConnection, command))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {                 
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }


    }
}
