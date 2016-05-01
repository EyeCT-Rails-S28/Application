using System;
using System.Collections.Generic;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsDatabase
{
    public class RideManagementSqlContext : IRideManagementContext
    {
        public void ReportStatusChange(int tramId, Status status)
        {
            string query = "UPDATE \"tram\" " +
                           "SET status = :tram_status " +
                           "WHERE id = :tram_id";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            Database.Instance.ExecuteQuery(query, parameters, QueryType.NonQuery);

            parameters.Add(":tram_status", Convert.ToString(status));
            parameters.Add(":tram_id", tramId);
        }
    }
}
