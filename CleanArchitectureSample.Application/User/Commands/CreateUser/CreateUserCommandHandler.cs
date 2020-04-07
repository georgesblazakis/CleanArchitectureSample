using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureSample.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitectureSample.Application.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUsersContext usersContext;
        private readonly IMediator mediator;

        public CreateUserCommandHandler(IUsersContext _usersContext, IMediator _mediator)
        {
            usersContext = _usersContext;
            mediator = _mediator;
        }

        public Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
