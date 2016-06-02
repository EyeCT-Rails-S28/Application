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
            string query = "SELECT id " +
                           "FROM \"user\" " +
                           "WHERE (email = :email AND password = :password)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {":email", email},
                {":password", password}
            };

            User ret;

            using (OracleDataReader reader = Database.Instance.ExecuteQuery(query, parameters, QueryType.Query))
            {
                if (!reader.Read())
                {
                    throw new OracleNullValueException();
                }

                int id = reader.GetInt32(0);
                ret = GetUser(id);
            }

            return ret;
        }

        public User GetUser(int userId)
        {
            string query =
                "SELECT u.id, u.name, u.email, r.description, r.id FROM \"user\" u, \"role\" r WHERE u.id = :id AND r.id = u.role_id";

            Dictionary<string, object> parameters = new Dictionary<string, object> {{":id", userId}};

            User ret;

            using (OracleDataReader reader = Database.Instance.ExecuteQuery(query, parameters, QueryType.Query))
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string email = reader.GetString(2);
                Role role = (Role) Enum.Parse(typeof (Role), reader.GetString(3));
                List<Right> rights = GetRights(reader.GetInt32(4));

                Function function = new Function(role, rights);
                ret = new User(id, name, email, function);
            }

            return ret;
        }

        private List<Right> GetRights(int roleId)
        {
            const string query =
                "SELECT r.description FROM \"right\" r, \"role_right\" rr WHERE r.id = rr.right_id AND rr.role_id = :id";

            Dictionary<string, object> parameters = new Dictionary<string, object> {{":id", roleId}};

            List<Right> ret = new List<Right>();

            using (OracleDataReader reader = Database.Instance.ExecuteQuery(query, parameters, QueryType.Query))
            {
                while (reader.Read())
                {
                    Right right = (Right)Enum.Parse(typeof(Right), reader.GetString(0));
                    ret.Add(right);
                }            
            }

            return ret;
        }
    }
}