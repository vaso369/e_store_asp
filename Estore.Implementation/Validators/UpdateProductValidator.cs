using Estore.Application.DataTransfer;
using Estore.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estore.Implementation.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        private readonly EstoreContext _context;
        public UpdateProductValidator(EstoreContext context)
        {
            _context = context;
            RuleFor(c => c.Name).NotEmpty().WithMessage("Product name is required").Must(n => _context.Products.Where(pr => pr.Name != n).All(p => p.Name != n)).WithMessage("Name already exist in database!")
                .MaximumLength(80).WithMessage("Product must have less than 80 characters.");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Description is required").MaximumLength(200).WithMessage("Product must have less than 200 characters.");
            RuleFor(c => c.Stock).NotEmpty().WithMessage("Stock is required");
            RuleFor(c => c.Price).NotEmpty().WithMessage("Price is required").GreaterThan(0).WithMessage("Price must be greater than 0!");


        }
    }

}
