using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.Exceptions
{
    public class ConflictOrderStatusException : Exception
    {
        public ConflictOrderStatusException(string message) : base($"{message}")
        {

        }
    }
}
