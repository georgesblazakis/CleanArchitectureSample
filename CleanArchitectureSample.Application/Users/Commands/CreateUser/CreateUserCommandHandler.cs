using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureSample.Application.Common.Interfaces;
using CleanArchitectureSample.Domain.Entities;
using MediatR;

namespace CleanArchitectureSample.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUsersContext usersContext;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public CreateUserCommandHandler(IUsersContext _usersContext, IMediator _mediator, IMapper _mapper)
        {
            usersContext = _usersContext;
            mediator = _mediator;
            mapper = _mapper;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request);
            usersContext.Users.Add(user);
            await usersContext.SaveChangesAsync(cancellationToken);
            await mediator.Publish(new UserCreatedNotification { UserId = user.Id }, cancellationToken);

            return Unit.Value;
        }
    }
}
