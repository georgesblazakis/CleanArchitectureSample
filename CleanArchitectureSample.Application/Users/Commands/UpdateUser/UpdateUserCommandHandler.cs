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
        private readonly IMapper mapper;

        public UpdateUserCommandHandler(IUsersContext _usersContext, IMapper _mapper)
        {
            usersContext = _usersContext;
            mapper = _mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await usersContext.Users.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            var user = mapper.Map<User>(request);
            usersContext.Users.Add(user);

            await usersContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
