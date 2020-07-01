using Estore.Application.DataTransfer;
using Estore.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estore.Implementation.Validators
{
    public class CreateOrderValidator : AbstractValidator<OrderDto>
    {
        private readonly EstoreContext _context;
   
        public CreateOrderValidator(EstoreContext context)
        {
            _context = context;

            RuleFor(o => o.Address)
                .NotEmpty()
                .WithMessage("Address is required")
                .MaximumLength(80)
                .WithMessage("Address must have less than 80 characters.");
            RuleFor(o => o.OrderLines)
                .NotEmpty()
                .WithMessage("There must be at least one product")
                .Must(ol => ol.Select(p => p.ProductId).Distinct().Count() == ol.Count())
                .WithMessage("You cannot order duplicate products!")
                 .DependentRules(() =>
                 {
                     RuleForEach(x => x.OrderLines).SetValidator
                         (new CreateOrderLineValidator(_context));
                 });


        }

       
    }
}
