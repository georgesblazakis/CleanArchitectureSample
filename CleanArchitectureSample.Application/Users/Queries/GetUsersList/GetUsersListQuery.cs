using System;
using MediatR;

namespace CleanArchitectureSample.Application.Users.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<GetUsersListViewModel>
    {
    }
}
