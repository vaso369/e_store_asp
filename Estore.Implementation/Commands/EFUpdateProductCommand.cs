using Estore.Application.Commands;
using Estore.Application.DataTransfer;
using Estore.DataAccess;
using Estore.Domain;
using Estore.Implementation.Services;
using Estore.Implementation.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estore.Implementation.Commands
{
    public class EFUpdateProductCommand : IUpdateProductCommand
    {
        private UpdateProductValidator _validator;
        private EstoreContext _context;

        public EFUpdateProductCommand(UpdateProductValidator validator, EstoreContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => 8;

        public string Name => "Updating product";

        public void Execute(UpdateProductDto request)
        {
            if(_context.Products.Any(pr => pr.Name == request.Name))
            {

            }
            _validator.ValidateAndThrow(request);

            var product = _context.Products.AsQueryable().Include(p => p.Prices).Where(p => p.Id == request.Id).FirstOrDefault();
      
            var pathImage = product.ImagePath;
            if (request.Image != null)
                pathImage = UploadService.UploadImage(request.Image);
            
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.Stock += request.Stock;
                product.ImagePath = pathImage;
                _context.SaveChanges();
                if(!_context.PriceHistory.Where(prod => prod.ProductId == request.Id).Any(price => price.Price == request.Price))
                {
                    var price = new PriceHistory
                    {
                        Price = request.Price,
                        ProductId = request.Id
                    };
                    _context.PriceHistory.Add(price);
                    _context.SaveChanges();
                }
               

                dbContextTransaction.Commit();
            }
           
        }
    }
}
