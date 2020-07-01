using Estore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.DataTransfer
{
    public class OrderDto 
    {
        public int UserId { get; set; }
        public string Address { get; set; }
        public PaymentOption PaymentOption { get; set; }
        public IEnumerable<OrderLineDto> OrderLines { get; set; }
    }

}
