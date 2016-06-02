using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsDatabase
{
    internal class DatabaseConfiguration
    {
        public const string DATABASE_USERNAME = "SYSTEM";
        public const string DATABASE_PASSWORD = "";
        public const string DATABASE_SERVICE = "orcl.168.0.27";
        public const string DATABASE_HOST = "jandiehendriks.com";
        public const int DATABASE_PORT = 1521;


        private DatabaseConfiguration()
        {
        }
    }
}
