using Estore.Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Implementation.Validators
{
    public class UpdateUserValidator : AbstractValidator<UserPutDto>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required").MaximumLength(25).WithMessage("First name must be less than 25 characters");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required").MaximumLength(35).WithMessage("Last name must be less than 35 characters");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email must be in valid format");

        }
    }
}
