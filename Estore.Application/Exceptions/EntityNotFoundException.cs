using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id, Type type) : base($"{type.Name} with an id of {id} was not found.")
        {

        }
    }
}
