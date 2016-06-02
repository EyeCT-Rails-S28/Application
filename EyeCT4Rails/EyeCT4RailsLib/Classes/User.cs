using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsLib.Classes
{
    public class User
    {
        /// <summary>
        /// The id of the user in the database.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// The name of the user.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The email of the user.
        /// </summary>
        public string Email { get;}
        /// <summary>
        /// The Role of the user.
        /// </summary>
        public Function Function { get; }

        /// <summary>
        /// Creates an user.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <param name="name">The name of the user.</param>
        /// <param name="email">The email of the user.</param>
        /// <param name="function">The function of the user.</param>
        public User(int id, string name, string email, Function function)
        {
            Id = id;
            Name = name;
            Email = email;
            Function = function;
        }

        /// <summary>
        /// Returns wheter a user has a certain Role.
        /// </summary>
        /// <param name="right">Right to check for.</param>
        /// <returns>A bool which specifies wheter the user has the Role.</returns>
        public bool HasRight(Right right)
        {
            return Function.Rights.Exists(x => x == right);
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Function.Role}";
        }
    }
}
