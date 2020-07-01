using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.DataTransfer
{
    public class ProductPictureDto
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int ProductId { get; set; }
    }
}
