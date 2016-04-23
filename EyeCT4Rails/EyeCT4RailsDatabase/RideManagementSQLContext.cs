using System;
using System.Data;
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
                                                      "SET status = :tram_status " +
                                                      "WHERE id = :tram_id", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new OracleParameter(":tram_status", OracleDbType.Varchar2)).Value = Convert.ToString(status);
            command.Parameters.Add(new OracleParameter(":tram_id", OracleDbType.Int32)).Value = tram.Id;

            command.ExecuteNonQuery();
        }
    }
}
