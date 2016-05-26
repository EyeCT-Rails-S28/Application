using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsLib
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
        public Role Role { get; }

        /// <summary>
        /// Creates an user.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <param name="name">The name of the user.</param>
        /// <param name="email">The email of the user.</param>
        /// <param name="role">The Role of the user.</param>
        public User(int id, string name, string email, Role role)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
        }

        /// <summary>
        /// Returns wheter a user has a certain Role.
        /// </summary>
        /// <param name="role">Role to check.</param>
        /// <returns>A bool which specifies wheter the user has the Role.</returns>
        public bool HasRole(Role role)
        {
            return Role == role || Role == Role.Administrator;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Role}";
        }
    }
}
