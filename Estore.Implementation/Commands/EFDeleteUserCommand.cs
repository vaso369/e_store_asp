﻿using Estore.Application.Commands;
using Estore.Application.Exceptions;
using Estore.DataAccess;
using Estore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Implementation.Commands
{
    public class EFDeleteUserCommand : IDeleteUserCommand
    {
        private readonly EstoreContext _context;

        public EFDeleteUserCommand(EstoreContext context)
        {
            _context = context;
        }

        public int Id => 18;

        public string Name => "Deleting profile";

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);
            if(user == null)
            {
                throw new EntityNotFoundException(request, typeof(User));
            }
            user.IsDeleted = true;
            user.IsActive = false;
            user.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
