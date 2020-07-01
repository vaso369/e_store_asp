using Estore.Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Implementation.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Category name is required").MaximumLength(30).WithMessage("Category must have less than 30 characters.");
        }
    }
}
