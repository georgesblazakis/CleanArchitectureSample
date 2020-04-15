using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureSample.Application.Common.Exceptions;
using CleanArchitectureSample.Application.Common.Interfaces;
using CleanArchitectureSample.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUsersContext usersContext;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public UpdateUserCommandHandler(IUsersContext _usersContext, IMediator _mediator, IMapper _mapper)
        {
            usersContext = _usersContext;
            mediator = _mediator;
            mapper = _mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await usersContext.Users.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Email = request.Email;
            entity.UserName = request.UserName;
            entity.PasswordHash = request.PasswordHash;

            //var user = mapper.Map<User>(request);
            await usersContext.SaveChangesAsync(cancellationToken);
            await mediator.Publish(new UserUpdatedNotification { UserId = entity.Id }, cancellationToken);
            return Unit.Value;
        }
    }
}
