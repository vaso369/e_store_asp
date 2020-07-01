using Estore.Application.Commands;
using Estore.Application.DataTransfer;
using Estore.DataAccess;
using Estore.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Implementation.Commands
{
    public class EFUpdateUserCommand : IUpdateUserCommand
    {
        private readonly EstoreContext _context;
        private readonly UpdateUserValidator _validator;

        public EFUpdateUserCommand(EstoreContext context, UpdateUserValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 17;

        public string Name => "Updating info";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);
            var user = _context.Users.Find(request.Id);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;

            _context.SaveChanges();
        }
    }
}
