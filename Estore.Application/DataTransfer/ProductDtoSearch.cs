using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.DataTransfer
{
    public class ProductDtoSearch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<PriceDtoSearch> Prices { get; set; }
        public IEnumerable<ImageDto> Pictures { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
