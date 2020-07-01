using Estore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.DataTransfer
{
    public class OrderSearchDto
    {
        public string UserName { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentOption PaymentOption { get; set; }
    }
}
