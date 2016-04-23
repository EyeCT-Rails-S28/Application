using System;
using EyeCT4RailsDatabase;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Exceptions;
using Oracle.ManagedDataAccess.Types;

namespace EyeCT4RailsLogic
{
    public class UserRepository
    {
        private static UserRepository _instance;
        private readonly IUserContext _context;

        private UserRepository()
        {
            _context = new UserSqlContext();
        }

        public static UserRepository Instance => _instance ?? (_instance = new UserRepository());

        /// <summary>
        /// Tries to fetch an user that has the same email and password as specified. Throws exception when the user is invalid.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <returns>The user object that </returns>
        public User LoginUser(string email, string password)
        {
            User user;

            try
            {
                user = _context.LoginUser(email, password);
            }
            catch (Exception e)
            {
                if(e is OracleNullValueException)
                    throw new InvalidUserException("Invalid username or password");

                ExceptionCatch(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }

            return user;
        }

        /// <summary>
        /// Creates a new user with the given information.
        /// </summary>
        /// <param name="name">Name of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <param name="email">Email of the user.</param>
        /// <param name="role">Role of the user.</param>
        /// <returns>The user that was created.</returns>
        public User CreateUser(string name, string password, string email, Role role)
        {
            try
            {
                return _context.CreateUser(name, password, email, role);
            }
            catch (Exception e)
            {
                ExceptionCatch(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }


        private void ExceptionCatch(Exception e)
        {
            Console.WriteLine(e.ToString());

            if (e.GetType() == typeof(OracleTypeException) || e.GetBaseException() is OracleTypeException)
                throw new DatabaseException("A database error has occured.", e);
        }
    }
}
