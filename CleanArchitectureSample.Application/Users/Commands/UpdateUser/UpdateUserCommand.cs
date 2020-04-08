using System;
using MediatR;

namespace CleanArchitectureSample.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }

        public UpdateUserCommand()
        {
        }
    }
}
