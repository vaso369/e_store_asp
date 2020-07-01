using Estore.Application.DataTransfer;
using Estore.Application.Searches;
using Estore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.Queries
{
    public interface IGetProductsQuery : IQuery<ProductSearch, PageResponse<ProductDtoSearch>>
    {
    }
}
