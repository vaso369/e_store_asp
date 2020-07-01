using Estore.Application.DataTransfer;
using Estore.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estore.Implementation.Validators
{
    public class CreateRoleValidator : AbstractValidator<RoleDto>
    {
        public CreateRoleValidator(EstoreContext context)
        {
            RuleFor(x => x.Name).NotEmpty().Must(name => !context.Roles.Any(r => r.Name == name)).WithMessage("Role name already exist");
        }
    }
}
