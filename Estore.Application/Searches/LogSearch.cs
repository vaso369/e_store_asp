using Estore.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.Searches
{
    public class LogSearch : PageSearch
    {
        public string UserData { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string UseCaseName { get; set; }
    }
}
