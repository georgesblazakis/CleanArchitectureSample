using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureSample.Application.Common.Exceptions;
using CleanArchitectureSample.Application.Common.Interfaces;
using CleanArchitectureSample.Domain.Entities;
using MediatR;

namespace CleanArchitectureSample.Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, GetUserDetailViewModel>
    {
        private readonly IUsersContext usersContext;
        private readonly IMapper mapper;

        public GetUserDetailQueryHandler(IUsersContext _userContext, IMapper _mapper)
        {
            usersContext = _userContext;
            mapper = _mapper;
        }

        public async Task<GetUserDetailViewModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await usersContext.Users.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            return mapper.Map<GetUserDetailViewModel>(entity);
        }
    }
}
