using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureSample.Application.Common.Exceptions;
using CleanArchitectureSample.Application.Common.Interfaces;
using CleanArchitectureSample.Domain.Entities;
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

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await usersContext.Users.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            usersContext.Users.Remove(entity);
            await usersContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
