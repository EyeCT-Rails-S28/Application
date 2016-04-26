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
    }
}
