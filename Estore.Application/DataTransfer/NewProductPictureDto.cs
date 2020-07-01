using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.DataTransfer
{
    public class NewProductPictureDto
    {
        public int ProductId { get; set; }
        public ICollection<IFormFile> Pictures { get; set; }
    }
}
