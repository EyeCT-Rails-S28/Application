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
        /// The privilege of the user.
        /// </summary>
        public Privilege Privilege { get; }

        /// <summary>
        /// Creates an user.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <param name="name">The name of the user.</param>
        /// <param name="email">The email of the user.</param>
        /// <param name="privilege">The privilege of the user.</param>
        public User(int id, string name, string email, Privilege privilege)
        {
            Id = id;
            Name = name;
            Email = email;
            Privilege = privilege;
        }

        /// <summary>
        /// Returns wheter a user has a certain privilege.
        /// </summary>
        /// <param name="privilege">Privilege to check.</param>
        /// <returns>A bool which specifies wheter the user has the privilege.</returns>
        public bool HasPrivilege(Privilege privilege)
        {
            return Privilege == privilege || Privilege == Privilege.Administrator;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Privilege}";
        }
    }
}
