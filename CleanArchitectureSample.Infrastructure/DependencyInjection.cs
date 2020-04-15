using System;
using CleanArchitectureSample.Application.Common;
using CleanArchitectureSample.Application.Common.Interfaces;
using CleanArchitectureSample.Infrastructure.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureSample.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddTransient<INotificationService, NotificationService>();

            return services;
        }
    }
}
