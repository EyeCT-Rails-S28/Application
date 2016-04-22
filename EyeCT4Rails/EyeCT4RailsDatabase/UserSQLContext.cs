using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using Oracle.ManagedDataAccess.Client;

namespace EyeCT4RailsDatabase
{
    public class UserSqlContext : IUserContext
    {
        public User CreateUser(string name, string password, string email, Role role)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("create_user", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("p_role", OracleDbType.Varchar2).Value = Convert.ToString(role));
            command.Parameters.Add(new OracleParameter("p_name", OracleDbType.Varchar2).Value = name);
            command.Parameters.Add(new OracleParameter("p_email", OracleDbType.Varchar2).Value = email);
            command.Parameters.Add(new OracleParameter("p_password", OracleDbType.Varchar2).Value = password);

            int id = Convert.ToInt32(command.ExecuteScalar());
            return new User(id, name, email, role);
        }

        public User LoginUser(string email, string password)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("login_user", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("p_email", OracleDbType.Varchar2).Value = email);
            command.Parameters.Add(new OracleParameter("p_password", OracleDbType.Varchar2).Value = password);

            OracleDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }

            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            Role role = (Role) Enum.Parse(typeof (Role), reader.GetString(2));
            return new User(id, name, email, role);
        }
    }
}
