using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitectureSample.Application.Common.Exceptions;
using CleanArchitectureSample.Application.Common.Interfaces;
using CleanArchitectureSample.Domain.Entities;
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
            var usersDTO = await usersContext.Users
                .ProjectTo<GetUserListDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (usersDTO == null)
            {
                throw new NotFoundException(nameof(User), request);
            }

            //var usersDTO = mapper.Map<List<User>, List<GetUserListDTO>>(users);
            var userList = new GetUsersListViewModel{ Users = usersDTO };

            return userList;
        }
    }
}
