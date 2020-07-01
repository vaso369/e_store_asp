using Estore.Application;
using Estore.Application.Commands;
using Estore.Application.DataTransfer;
using Estore.Application.Email;
using Estore.DataAccess;
using Estore.Domain;
using Estore.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Implementation.Commands
{
    public class EFCreateUserCommand : ICreateUserCommand
    {
        private readonly EstoreContext _context;
        private readonly CreateUserValidator _validator;
        private readonly IEmailSender _sender;

        public EFCreateUserCommand(EstoreContext context, CreateUserValidator validator, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
        }
        public int Id => 3;

        public string Name => "Creating user";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Pass = request.Pass,
                PID = request.PID,
                RoleId = 2
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            _sender.Send(new SendEmailDto
            {
                Content = "<h1>You are successfully registrated now!</h1>",
                SendTo = request.Email,
                Subject = "E-store registration"
            });
        }
    }
}
