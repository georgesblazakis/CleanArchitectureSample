using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureSample.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitectureSample.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUsersContext usersContext;

        public DeleteUserCommandHandler(IUsersContext _usersContext)
        {
            usersContext = _usersContext;
        }

        public Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
