using Estore.Application.Commands;
using Estore.Application.DataTransfer;
using Estore.DataAccess;
using Estore.Domain;
using Estore.Implementation.Services;
using Estore.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Estore.Implementation.Commands
{
    public class EFCreateProductCommand : ICreateProductCommand
    {
        private CreateProductValidator _validator;
        private EstoreContext _context;

        public EFCreateProductCommand(CreateProductValidator validator, EstoreContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => 5;

        public string Name => "Creating new product";

        public void Execute(ProductDto request)
        {
            _validator.ValidateAndThrow(request);
            var paths = UploadService.UploadImages(request.Images);
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Stock = request.Stock,
                ImagePath = paths[0],
                CategoryId = request.CategoryId

            };

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                int LastProductId = product.Id;
                for (int i = 1; i < paths.Count; i++)
                {
                    var productPicture = new Picture
                    {
                        ImagePath = paths[i],
                        ProductId = LastProductId
                    };
                    _context.Pictures.Add(productPicture);
                }
                _context.SaveChanges();

                var price = new PriceHistory
                {
                    Price = request.Price,
                    ProductId = LastProductId
                };
                _context.PriceHistory.Add(price);
                _context.SaveChanges();
                dbContextTransaction.Commit();
            }
        }
    }
}
