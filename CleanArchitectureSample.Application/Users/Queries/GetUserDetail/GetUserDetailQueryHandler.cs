using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureSample.Application.Common.Interfaces;
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

        public Task<GetUserDetailViewModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
