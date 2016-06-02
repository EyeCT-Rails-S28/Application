﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Function(Role role, List<Right> rights)
        {
            Role = role;
            _rights = rights;
        }
    }
}