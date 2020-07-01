using Estore.Application.DataTransfer;
using Estore.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.Queries
{
    public interface IGetUsersQuery : IQuery<UserSearch, PageResponse<UserDto>>
    {
    }
}
