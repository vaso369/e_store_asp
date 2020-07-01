using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Domain
{
    public class PriceHistory : Entity
    {
        public decimal Price { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }


    }
}
