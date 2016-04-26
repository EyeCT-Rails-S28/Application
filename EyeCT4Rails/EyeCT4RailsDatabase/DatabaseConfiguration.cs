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
        public const string DATABASE_PASSWORD = "43594";
        public const string DATABASE_SERVICE = "orcl";
        public const string DATABASE_HOST = "127.0.0.1";
        public const int DATABASE_PORT = 1521;


        private DatabaseConfiguration()
        {
        }
    }
}
