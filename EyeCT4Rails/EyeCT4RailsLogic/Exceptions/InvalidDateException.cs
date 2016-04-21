using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsLogic.Exceptions
{
    public class InvalidDateException : Exception
    {
        public InvalidDateException(string message) : base(message)
        {
        }
    }
}
