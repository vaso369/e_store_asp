using Estore.Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Implementation.Validators
{
    public class CreateProductValidator : AbstractValidator<ProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Product name is required").MaximumLength(80).WithMessage("Product must have less than 80 characters.");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Description is required").MaximumLength(200).WithMessage("Product must have less than 200 characters.");
            RuleFor(c => c.Stock).NotEmpty().WithMessage("Stock is required");
            RuleFor(c => c.Price).NotEmpty().WithMessage("Price is required");


        }
    }
}
