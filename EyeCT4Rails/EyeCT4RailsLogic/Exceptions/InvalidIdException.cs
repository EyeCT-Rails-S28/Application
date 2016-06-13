using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsLogic.Exceptions
{
    public class InvalidIdException : CustomException
    {
        public InvalidIdException(string message) : base(message)
        {
            
        }
    }
}
