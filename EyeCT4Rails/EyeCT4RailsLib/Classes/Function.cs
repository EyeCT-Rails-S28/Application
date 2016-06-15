using System.Collections.Generic;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsLib.Classes
{
    public class Function
    {
        private readonly List<Right> _rights; 

        /// <summary>
        /// The name of the function.
        /// </summary>
        public Role Role { get; }
        /// <summary>
        /// The rights of the function.
        /// </summary>
        public List<Right> Rights => new List<Right>(_rights);

        /// <summary>
        /// Constructs a function class.
        /// </summary>
        /// <param name="role">The role of the function.</param>
        /// <param name="rights">The rights of the function.</param>
        public Function(Role role, List<Right> rights)
        {
            Role = role;
            _rights = rights;
        }
    }
}
