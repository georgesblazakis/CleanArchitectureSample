using System;
using MediatR;

namespace CleanArchitectureSample.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public UpdateUserCommand()
        {
        }
    }
}
