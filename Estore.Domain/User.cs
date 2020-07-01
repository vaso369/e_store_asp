using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public long PID { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<UserUseCase> UserUseCases { get; set; } 
    }
}
