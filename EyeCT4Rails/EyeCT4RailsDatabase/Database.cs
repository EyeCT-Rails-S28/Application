using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace EyeCT4RailsDatabase
{
    public class Database
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly string CONNECTION_STRING =
            $"data source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = {DatabaseConfiguration.DATABASE_HOST})(PORT = {DatabaseConfiguration.DATABASE_PORT})))(CONNECT_DATA =(SERVICE_NAME = {DatabaseConfiguration.DATABASE_SERVICE})));USER ID={DatabaseConfiguration.DATABASE_USERNAME};PASSWORD={DatabaseConfiguration.DATABASE_PASSWORD}";

        private static Database _instance;

        public static Database Instance
        {
            get
            {
                if (_instance == null || !_instance.IsConnected)
                {
                    return _instance = new Database();
                }
                return _instance;
            }
        }

        private bool IsConnected => Connection.State == ConnectionState.Open;

        public OracleConnection Connection { get; }

        private Database()
        {
            Connection = new OracleConnection {ConnectionString = CONNECTION_STRING};

            Open();
        }

        ~Database()
        {
            Close();
        }

        private void Open()
        {
            Connection.Open();
        }

        private void Close()
        {
            Connection.Close();
        }

        public OracleDataReader ExecuteQuery(string query, Dictionary<string, object> parameters, QueryType queryType)
        {
            OracleConnection connection = Instance.Connection;
            using (OracleCommand command = new OracleCommand(query, connection) {CommandType = CommandType.Text})
            {
                foreach (KeyValuePair<string, object> entry in parameters)
                {
                    command.Parameters.Add(new OracleParameter(entry.Key, entry.Value));
                }

                if (queryType == QueryType.Query)
                    return command.ExecuteReader();
                command.ExecuteNonQuery();
                return null;
            }
        }

        public OracleDataReader ExecuteQuery(string query, QueryType queryType)
        {
           return ExecuteQuery(query, new Dictionary<string, object>(), queryType);
        }
    }

    public enum QueryType
    {
        Query = 1,
        NonQuery = 0
    }
}
