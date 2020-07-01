using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Estore.Application
{
    public interface IApplicationActor
    {
         int Id { get; }
         string Identity { get; }
        IEnumerable<int> AllowedUseCases { get; }

    }
}
