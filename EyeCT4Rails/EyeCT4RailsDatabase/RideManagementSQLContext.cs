using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using Oracle.ManagedDataAccess.Client;

namespace EyeCT4RailsDatabase
{
    public class RideManagementSqlContext : IRideManagementContext
    {
        public void ReportStatusChange(Tram tram, Status status)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("UPDATE \"tram\" " +
                                                      "SET status = :status " +
                                                      "WHERE id = :id", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter(":status", OracleDbType.Varchar2)).Value = Convert.ToString(status);
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = tram.Id;

            command.ExecuteNonQuery();
        }
    }
}
