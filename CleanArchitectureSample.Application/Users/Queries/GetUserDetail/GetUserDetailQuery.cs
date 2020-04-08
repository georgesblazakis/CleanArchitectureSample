using System;
using MediatR;

namespace CleanArchitectureSample.Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailQuery : IRequest<GetUserDetailViewModel>
    {
        public int Id { get; set; }
    }
}
