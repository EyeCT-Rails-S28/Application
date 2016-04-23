using System;
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
        private const string CONNECTION_STRING = "data source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = orcl)));USER ID=SYSTEM;PASSWORD=43594";

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
                Console.WriteLine("Error connecting: " + e.ToString());
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
