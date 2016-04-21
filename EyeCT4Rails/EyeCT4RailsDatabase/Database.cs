using System;
using Oracle.ManagedDataAccess.Client;

namespace EyeCT4RailsDatabase
{
    public class Database
    {
        /// <summary>
        /// 
        /// </summary>
        private const string CONNECTION_STRING = "";

        public static Database Instance { get; } = new Database();

        public OracleConnection Connection { get; private set; }

        private Database()
        {
            Connection = new OracleConnection();
            Connection.ConnectionString = CONNECTION_STRING;
        }

        public bool Open()
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch (OracleException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool Close()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (OracleException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

    }
}
