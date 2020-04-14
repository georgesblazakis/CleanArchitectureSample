using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitectureSample.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

        public async Task<GetUsersListViewModel> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var users = await usersContext.Users.ProjectTo<GetUserListDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var userList = new GetUsersListViewModel
            {
                Users = users
            };

            return userList;
        }
    }
}
