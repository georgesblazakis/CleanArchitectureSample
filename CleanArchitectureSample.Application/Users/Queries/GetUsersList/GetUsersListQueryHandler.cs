using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureSample.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitectureSample.Application.Users.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, GetUsersListViewModel>
    {
        private readonly IUsersContext usersContext;
        private readonly IMapper mapper;

        public GetUsersListQueryHandler(IUsersContext _usersContext, IMapper _mapper)
        {
            usersContext = _usersContext;
            mapper = _mapper;
        }

        public Task<GetUsersListViewModel> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
