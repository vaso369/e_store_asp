using Estore.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.Searches
{
    public class ProductSearch : PageSearch
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public int CategoryId { get; set; }
        public bool Stock { get; set; }
         
        
    }
}
