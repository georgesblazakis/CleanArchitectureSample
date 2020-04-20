using System;
using CleanArchitectureSample.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureSample.Infrastructure.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            
            services.AddDbContext<UsersContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUsersContext>(provider => provider.GetService<UsersContext>());

            return services;
        }
    }
}
