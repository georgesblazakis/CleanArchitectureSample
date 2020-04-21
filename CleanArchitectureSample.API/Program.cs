using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CleanArchitectureSample.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureSample.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();            
            using (var scope = host.Services.CreateScope()) {

                var services = scope.ServiceProvider;
                try
                {
                    var usersContext = services.GetRequiredService<UsersContext>();
                    usersContext.Database.Migrate();
                }
                catch (System.Exception)
                {
                    //var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    //logger.LogError(ex, "Error occurred while migrating or initializing the database.");   
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
