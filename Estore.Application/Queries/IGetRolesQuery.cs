using Estore.Application.DataTransfer;
using Estore.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.Queries
{
    public interface IGetRolesQuery : IQuery<RoleSearch, PageResponse<RoleDto>>
    {

    }
}
