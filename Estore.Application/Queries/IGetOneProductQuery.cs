using Estore.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.Queries
{
    public interface IGetOneProductQuery : IQuery<int, ProductDtoSearch>
    {
    }
}
