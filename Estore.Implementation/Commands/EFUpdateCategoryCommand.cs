using Estore.Application.Commands;
using Estore.Application.DataTransfer;
using Estore.Application.Exceptions;
using Estore.DataAccess;
using Estore.Domain;
using Estore.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Implementation.Commands
{
    public class EFUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly EstoreContext _context;
        private readonly CreateCategoryValidator _validator;

        public EFUpdateCategoryCommand(EstoreContext context, CreateCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 21;

        public string Name => "Updating category";

        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);
            var category = _context.Categories.Find(request.Id);

            if(category == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Category));
            }

            category.Name = request.Name;

            _context.SaveChanges();
        }
    }
}
