using Estore.Application.Commands;
using Estore.Application.DataTransfer;
using Estore.DataAccess;
using Estore.Domain;
using Estore.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Implementation.Commands
{
    public class EFCreateCategoryCommand : ICreateCategoryCommand
    {
        private EstoreContext _context;
        private CreateCategoryValidator _validator;

        public EFCreateCategoryCommand(EstoreContext context, CreateCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 4;

        public string Name => "Creating category";

        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);

            var category = new Category
            {
                Name = request.Name
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}
