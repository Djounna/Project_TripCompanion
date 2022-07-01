using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.DBConnections
{
    // Toolbox ADO to use with stored procedure (SP).
    /* The toolbox creates the connection, the command (given as a CommandSP object containing a string : the name of the SP in the DB) and the parameters (given through the CommandSP object) */
    public class CommandSP
    {
        internal string StoredProcedure { get; init; }      
        internal Dictionary<string, object> Parameters { get; init; }

        public CommandSP(string storedProcedure)
        {
            StoredProcedure = storedProcedure;
            Parameters = new Dictionary<string, object>();
        }

        public void AddParameter(string parameterName, object? value)
        {
            Parameters.Add(parameterName, value ?? DBNull.Value);
        }
    }
}
