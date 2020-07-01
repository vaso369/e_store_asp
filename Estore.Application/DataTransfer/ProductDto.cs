using Estore.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.DataTransfer
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int Stock { get; set; }
        public ICollection<IFormFile> Images { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
