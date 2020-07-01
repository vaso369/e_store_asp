using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.DataTransfer
{
    public class UserSearchDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PID { get; set; }
    }
}
