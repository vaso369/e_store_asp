using Estore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.DataTransfer
{
    public class OrderWithUserDataDto 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PID { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public PaymentOption PaymentOption { get; set; }
        public IEnumerable<OrderLineDto> OrderLines { get; set; }
    }
}
