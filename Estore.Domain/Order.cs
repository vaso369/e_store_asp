using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Domain
{
    public class Order : Entity
    {

        public int UserId { get; set; }
        public string Address { get; set; }

        public virtual User User { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentOption PaymentOption { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();
    }
    public enum OrderStatus
    {
        OnHold,
        Delivered,
        Shipped,
        Canceled
    }
    public enum PaymentOption
    {
        Cash,
        CreditCard
    }
}
