using Estore.Application.Commands;
using Estore.Application.Exceptions;
using Estore.DataAccess;
using Estore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Implementation.Commands
{
    public class EFDeleteProductCommand : IDeleteProductCommand
    {
        private readonly EstoreContext _context;

        public EFDeleteProductCommand(EstoreContext context)
        {
            _context = context;
        }

        public int Id => 12;

        public string Name => "Deleting product";

        public void Execute(int request)
        {
            var product = _context.Products.Find(request);
            if(product == null)
            {
                throw new EntityNotFoundException(request, typeof(Product));
            }
            product.IsDeleted = true;
            product.IsActive = false;
            product.DeletedAt = DateTime.Now;

            _context.SaveChanges();

        }
    }
}
