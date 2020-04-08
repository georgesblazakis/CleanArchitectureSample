using System;
using MediatR;

namespace CleanArchitectureSample.Application.Users.Commands.CreateUser
{
    public class UserCreatedNotification : INotification
    {
        public int UserId { get; set; }
    }
}
