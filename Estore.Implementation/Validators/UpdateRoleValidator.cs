using Estore.Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Implementation.Validators
{
    public class UpdateRoleValidator : AbstractValidator<RolePutDto>
    {
        public UpdateRoleValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Role name is required").MaximumLength(30).WithMessage("Role must have less than 30 characters.");
        }
    }
}
