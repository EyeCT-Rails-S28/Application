using System;
using System.Collections.Generic;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsDatabase.SQLContexts
{
    public class RideManagementSqlContext : IRideManagementContext
    {
        public void ReportStatusChange(int tramId, Status status)
        {
            string query = "UPDATE \"tram\" " +
                           "SET status = :tram_status " +
                           "WHERE id = :tram_id";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {":tram_status", Convert.ToString(status)},
                {":tram_id", tramId}
            };

            Database.Instance.ExecuteQuery(query, parameters, QueryType.NonQuery);
        }
    }
}
