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

        public void Execute(UserPostDto request)
        {
            _validator.ValidateAndThrow(request);
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
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

                var authUseCases = new List<int> { 13, 17, 23, 7, 6,18 };
                foreach (var useCase in authUseCases)
                {
                    var useCaseRow = new UserUseCase
                    {
                        UserId = user.Id,
                        UseCaseId = useCase
                    };
                    _context.UserUseCases.Add(useCaseRow);
                }
                _context.SaveChanges();
                dbContextTransaction.Commit();
            }
            _sender.Send(new SendEmailDto
            {
                Content = "<h1>You are successfully registrated now!</h1>",
                SendTo = request.Email,
                Subject = "E-store registration"
            });
        }
    }
}
