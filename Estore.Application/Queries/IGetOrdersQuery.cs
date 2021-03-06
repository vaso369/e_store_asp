﻿using Estore.Application.DataTransfer;
using Estore.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.Queries
{
    public interface IGetOrdersQuery : IQuery<OrderSearch, PageResponse<OrderWithUserDataDto>>
    {
    }
}
