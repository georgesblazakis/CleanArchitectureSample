using System;
using System.Collections.Generic;

namespace CleanArchitectureSample.Application.Users.Queries.GetUsersList
{
    public class GetUsersListViewModel
    {
        public IList<GetUserListDTO> Users { get; set; }
    }

    public class GetUserListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
