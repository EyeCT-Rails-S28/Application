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
using Oracle.ManagedDataAccess.Types;

namespace EyeCT4RailsDatabase
{
    public class UserSqlContext : IUserContext
    {
        public User CreateUser(string name, string password, string email, Role role)
        {
            try
            {
                OracleConnection connection = Database.Instance.Connection;
                OracleCommand command = new OracleCommand("INSERT INTO \"user\" (role, name, email, password) " +
                                                          "VALUES(:role, :name, :email, :password)", connection);

                command.CommandType = CommandType.Text;

                command.Parameters.Add(new OracleParameter(":role", OracleDbType.Varchar2)).Value =
                    Convert.ToString(role);
                command.Parameters.Add(new OracleParameter(":name", OracleDbType.Varchar2)).Value = name;
                command.Parameters.Add(new OracleParameter(":email", OracleDbType.Varchar2)).Value = email;
                command.Parameters.Add(new OracleParameter(":password", OracleDbType.Varchar2)).Value = password;

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return GetNewestUser(name, email, role);
        }

        private User GetNewestUser(string name, string email, Role role)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("SELECT MAX(id) " +
                                                       "FROM \"user\"", connection);
            command.CommandType = CommandType.Text;

            int id = Convert.ToInt32(command.ExecuteScalar());
            return new User(id, name, email, role);
        }

        public User LoginUser(string email, string password)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("SELECT id, role, name " +
                                                      "FROM \"user\" " +
                                                      "WHERE (email = :email AND password = :password)", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new OracleParameter(":email", OracleDbType.Varchar2)).Value = email;
            command.Parameters.Add(new OracleParameter(":password", OracleDbType.Varchar2)).Value = password;

            OracleDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                throw new OracleNullValueException();
            }

            int id = reader.GetInt32(0);
            string name = reader.GetString(2);
            Role role = (Role) Enum.Parse(typeof (Role), reader.GetString(1));
            return new User(id, name, email, role);
        }
    }
}
