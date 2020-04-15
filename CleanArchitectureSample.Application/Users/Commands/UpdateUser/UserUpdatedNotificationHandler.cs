using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureSample.Application.Common.Interfaces;
using CleanArchitectureSample.Application.Common.Notifications.Models;
using MediatR;

namespace CleanArchitectureSample.Application.Users.Commands.UpdateUser
{
    public class UserUpdatedNotificationHandler : INotificationHandler<UserUpdatedNotification>
    {
        private readonly INotificationService noticationService;

        public UserUpdatedNotificationHandler(INotificationService _noticationService)
        {
            noticationService = _noticationService;
        }

        public async Task Handle(UserUpdatedNotification notification, CancellationToken cancellationToken)
        {
            await noticationService.SendAsync(new Message());
        }
    }
}
