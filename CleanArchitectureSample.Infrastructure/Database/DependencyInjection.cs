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
            
            if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                services.AddDbContext<UsersContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            else
                services.AddDbContext<UsersContext>(options =>
                    options.UseSqlite("Data Source=user.db"));

            services.AddScoped<IUsersContext>(provider => provider.GetService<UsersContext>());
            services.BuildServiceProvider().GetService<UsersContext>().Database.Migrate();

            return services;
        }
    }
}
