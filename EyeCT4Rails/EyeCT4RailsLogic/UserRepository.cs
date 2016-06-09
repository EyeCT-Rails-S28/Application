using System;
using EyeCT4RailsDatabase;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Exceptions;
using EyeCT4RailsLogic.Helpers;
using Oracle.ManagedDataAccess.Client;
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

        /// <summary>
        /// The instance of the singleton UserRepository.
        /// </summary>
        public static UserRepository Instance => _instance ?? (_instance = new UserRepository());

        /// <summary>
        /// Tries to fetch an user that has the same email and password as specified. Throws exception when the user is invalid.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <returns>The user object that contains all the user information.</returns>
        public User LoginUser(string email, string password)
        {
            User user;

            try
            {
                var salt = _context.GetSalt(email);
                var hash = Hashing.HashString(password, salt);
                user = _context.LoginUser(email, hash);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                if(e is OracleException || e.GetBaseException() is OracleException || e is OracleTypeException || e.GetBaseException() is OracleTypeException)
                    throw new InvalidUserException("Invalid username or password", e);
                              
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
        public void CreateUser(string name, string password, string email, Role role)
        {
            try
            {
                var salt = Hashing.GetNewSalt();
                var hash = Hashing.HashString(password, salt);
                 _context.CreateUser(name, hash, email, role, salt);
            }
            catch (Exception e)
            {
                LogicExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }
    }
}
