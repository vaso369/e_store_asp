using Estore.Application.Commands;
using Estore.Application.Exceptions;
using Estore.DataAccess;
using Estore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estore.Implementation.Commands
{
    public class EFDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly EstoreContext _context;

        public EFDeleteCategoryCommand(EstoreContext context)
        {
            _context = context;
        }

        public int Id => 22;

        public string Name => "Deleting category";

        public void Execute(int request)
        {
            var category = _context.Categories.Find(request);
            if(category == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                category.IsActive = false;
                category.IsDeleted = true;
                category.DeletedAt = DateTime.Now;
                _context.SaveChanges();
                var products = _context.Products.Where(p => p.CategoryId == category.Id);

                foreach (var product in products)
                {
                    product.IsActive = false;
                    product.IsDeleted = true;
                    product.DeletedAt = DateTime.Now;
                }
                _context.SaveChanges();
                dbContextTransaction.Commit();
            }
        }
    }
}
