using Estore.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.Queries
{
    public interface IGetOneProductPicturesQuery : IQuery<int, IEnumerable<ProductPictureDto>>
    {
    }
}
