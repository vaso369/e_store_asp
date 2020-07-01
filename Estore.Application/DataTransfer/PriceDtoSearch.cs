using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.DataTransfer
{
    public class PriceDtoSearch
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
