using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string name, Type type) : base($"{name} already exist in {type.Name} table!")
        {

        }
    }
}
