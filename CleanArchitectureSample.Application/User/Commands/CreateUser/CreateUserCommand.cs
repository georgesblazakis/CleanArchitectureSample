using System;
using MediatR;

namespace CleanArchitectureSample.Application.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
