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
    public class EFUpdateRoleCommand : IUpdateRoleCommand
    {
        private readonly EstoreContext _context;
        private readonly UpdateRoleValidator _validator;

        public EFUpdateRoleCommand(EstoreContext context, UpdateRoleValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 24;

        public string Name => "Updating role";

        public void Execute(RolePutDto request)
        {
            _validator.ValidateAndThrow(request);

            var role = _context.Roles.Find(request.Id);

            if(role == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Role));
            }

            role.Name = request.Name;
            _context.SaveChanges();
        }
    }
}
