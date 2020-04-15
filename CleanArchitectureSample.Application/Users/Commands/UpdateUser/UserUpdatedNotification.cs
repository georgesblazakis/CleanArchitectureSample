using System;
using MediatR;

namespace CleanArchitectureSample.Application.Users.Commands.UpdateUser
{
    public class UserUpdatedNotification : INotification
    {
        public int UserId { get; set; }
    }
}
