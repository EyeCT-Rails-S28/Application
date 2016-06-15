using System;
using System.Collections.Generic;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsDatabase.SQLContexts;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Exceptions;
using EyeCT4RailsLogic.Utilities;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace EyeCT4RailsLogic.Repositories
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
                var hash = HashingUtil.HashString(password, salt);
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
                if (email.Contains("@"))
                {
                    email = email.Substring(0, email.IndexOf("@", StringComparison.Ordinal));
                }

                email += "@tranviaremise.com";

                if (!MailUtil.IsValidEmail(email))
                {
                    throw new InvalidEmailException($"The specified email address ({email}) is not a valid email address.");
                }

                var salt = HashingUtil.GetNewSalt();
                var hash = HashingUtil.HashString(password, salt);
                 _context.CreateUser(name, hash, email, role, salt);
            }
            catch (Exception e)
            {
                ExceptionHandler.FilterCustomException(e);
                ExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Gets a user based on its ID.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>User for given id, null if the user doesn't exist.</returns>
        public User GetUser(int userId)
        {
            try
            {
                return _context.GetUser(userId);
            }
            catch (Exception e)
            {
                ExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Gets list of users with a specific role.
        /// </summary>
        /// <param name="role">Role of user.</param>
        /// <returns>List of users with a specific role.</returns>
        public List<User> GetUsers(Role role)
        {
            try
            {
                return _context.GetUsers(role);
            }
            catch (Exception e)
            {
                ExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }
    }
}
