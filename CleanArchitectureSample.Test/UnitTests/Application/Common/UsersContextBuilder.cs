using System;
using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Test.UnitTests.Application.Common
{
    public class UsersContextBuilder
    {
        public static UsersContext Create()
        {
            var options = new DbContextOptionsBuilder<UsersContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new UsersContext(options);
            context.Database.EnsureCreated();

            context.Users.AddRange(new[] {
                new User { Id = 5, FirstName = "Peter", LastName = "Jun", Email = "Peter.j@gmail.com", UserName = "Peter.j", PasswordHash = "123456"},
                new User { Id = 6, FirstName = "John", LastName = "Marqs", Email = "John.m@gmail.com", UserName = "John.m", PasswordHash = "1234567"},
                new User { Id = 7, FirstName = "Marc", LastName = "Sial", Email = "Marc.s@gmail.com", UserName = "Marc.s", PasswordHash = "12345678"}
            });
            context.SaveChanges();
            return context;
        }

        public static void Delete(UsersContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }


     }
}
