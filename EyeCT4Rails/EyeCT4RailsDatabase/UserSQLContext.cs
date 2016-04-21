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
    // ReSharper disable once InconsistentNaming
    public class UserSQLContext : IUserContext
    {
        public User CreateUser(string name, string password, string email, Privilege privilege)
        {
            throw new NotImplementedException();
        }

        public User LoginUser(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
