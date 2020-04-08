using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureSample.Application.Common.Interfaces;
using CleanArchitectureSample.Application.Common.Notifications.Models;
using MediatR;

namespace CleanArchitectureSample.Application.Users.Commands.CreateUser
{
    public class UserCreatedNotificationHandler : INotificationHandler<UserCreatedNotification>
    {
        private readonly INotificationService noticationService;

        public UserCreatedNotificationHandler(INotificationService _noticationService)
        {
            noticationService = _noticationService;
        }

        public async Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
        {
            await noticationService.SendAsync(new Message());
        }
    }
}
