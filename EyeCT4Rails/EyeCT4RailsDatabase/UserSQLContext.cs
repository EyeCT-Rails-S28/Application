using System;
using System.Collections.Generic;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace EyeCT4RailsDatabase
{
    public class UserSqlContext : IUserContext
    {
        public void CreateUser(string name, string password, string email, Role role)
        {
            string query = "INSERT INTO \"user\" (role, name, email, password) " +
                           "VALUES(:role, :name, :email, :password)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {":role", role.ToString()},
                {":name", name},
                {":email", email},
                {":password", password}
            };

            Database.Instance.ExecuteQuery(query, parameters, QueryType.NonQuery);
        }

        public User LoginUser(string email, string password)
        {
            string query = "SELECT id, role, name " +
                           "FROM \"user\" " +
                           "WHERE (email = :email AND password = :password)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {":email", email},
                {":password", password}
            };

            using (OracleDataReader reader = Database.Instance.ExecuteQuery(query, parameters, QueryType.Query))
            {
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
}