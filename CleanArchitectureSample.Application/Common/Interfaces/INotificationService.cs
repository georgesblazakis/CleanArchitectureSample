using System;
using System.Threading.Tasks;
using CleanArchitectureSample.Application.Common.Notifications.Models;

namespace CleanArchitectureSample.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
