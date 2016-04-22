using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;

namespace EyeCT4RailsDatabase
{
    internal class Database
    {
        /// <summary>
        /// 
        /// </summary>
        private const string CONNECTION_STRING = "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XXX)));User ID=PTS36;PASSWORD=PTS36;";

        public static Database Instance { get; } = new Database();

        public OracleConnection Connection { get; private set; }

        private Database()
        {
            Connection = new OracleConnection();
            Connection.ConnectionString = CONNECTION_STRING;

            Open();
        }

        ~Database()
        {
            Close();
        }

        private bool Open()
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

        private bool Close()
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
