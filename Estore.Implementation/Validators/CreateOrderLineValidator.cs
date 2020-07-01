using Estore.Application.DataTransfer;
using Estore.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estore.Implementation.Validators
{
    public class CreateOrderLineValidator : AbstractValidator<OrderLineDto>
    {
        private readonly EstoreContext _context;
        public CreateOrderLineValidator(EstoreContext context)
        {
            _context = context;


            RuleFor(x => x.ProductId)
                .Must(ProductExists)
                .WithMessage("Product with an id of {PropertyValue} doesn't exist.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Quantity)
                    .GreaterThan(0)
                    .WithMessage("Quantity must be greater than 0")
                    .Must(QuantityDoesentExeedProductQuantity)
                    .WithMessage("Defined quantity ({PropertyValue}) is unavailable.");
                });
        }

        private bool ProductExists(int productId)
        {
            return _context.Products.Any(x => x.Id == productId);
        }

        private bool QuantityDoesentExeedProductQuantity(OrderLineDto dto, int quantity)
        {
            return _context.Products.Find(dto.ProductId).Stock >= quantity;
        }
    }
}
