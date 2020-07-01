using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.Queries
{
    public abstract class PageSearch
    {
        public int PerPage { get; set; } = 3;
        public int Page { get; set; } = 1;
    }
}
