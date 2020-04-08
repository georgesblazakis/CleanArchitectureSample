using System;
using MediatR;

namespace CleanArchitectureSample.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
