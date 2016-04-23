using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace EyeCT4RailsDatabase
{
    public class Database
    {
        /// <summary>
        /// 
        /// </summary>
        private const string CONNECTION_STRING =
            "data source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 172.20.36.2)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = XE)));USER ID=PTS36;PASSWORD=PTS36";

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
