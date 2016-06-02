﻿using EyeCT4RailsLib;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsDatabase.Models
{
    public interface IUserContext
    {
        /// <summary>
        /// Creates a user with the given information.
        /// </summary>
        /// <param name="name">Name of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <param name="email">Email of the user.</param>
        /// <param name="role">Role of the user.</param>
        void CreateUser(string name, string password, string email, Role role);

        /// <summary>
        /// Tries to login an user with the given email and password.
        /// </summary>
        /// <param name="email">Email of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <returns></returns>
        User LoginUser(string email, string password);

        /// <summary>
        /// Gets an user from the database with the given id.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>The user with the given id.</returns>
        User GetUser(int id);
    }
}
