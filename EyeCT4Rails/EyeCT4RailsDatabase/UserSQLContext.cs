using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsDatabase
{
    public class UserSqlContext : IUserContext
    {
        public User CreateUser(string name, string password, string email, Role role)
        {
            throw new NotImplementedException();
        }

        public User LoginUser(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
