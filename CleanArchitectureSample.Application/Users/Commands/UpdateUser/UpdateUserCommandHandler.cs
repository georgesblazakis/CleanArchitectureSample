using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureSample.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitectureSample.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUsersContext usersContext;

        public UpdateUserCommandHandler(IUsersContext _usersContext)
        {
            usersContext = _usersContext;
        }

        public Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
