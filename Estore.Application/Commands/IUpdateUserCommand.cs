using Estore.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.Commands
{
    public interface IUpdateUserCommand : ICommand<UserDto>
    {
    }
}
