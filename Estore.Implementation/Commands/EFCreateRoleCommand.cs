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
    public class EFCreateRoleCommand : ICreateRoleCommand
    {
        private readonly EstoreContext _context;
        private readonly CreateRoleValidator _validator;

        public EFCreateRoleCommand(EstoreContext context, CreateRoleValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 1;

        public string Name => "Creating new group using Entity Framework";

        public void Execute(RoleDto request)
        {
            _validator.ValidateAndThrow(request);
            var role = new Role
            {
                Name = request.Name
            };

            _context.Roles.Add(role);
            _context.SaveChanges();
        }
    }
}
