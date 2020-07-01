using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int Stock { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<PriceHistory> Prices { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();



    }
}
