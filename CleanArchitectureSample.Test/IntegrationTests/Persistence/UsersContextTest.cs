﻿using System;
using System.Threading.Tasks;
using CleanArchitectureSample.Application.Common.Interfaces;
using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitectureSample.Test.IntegrationTests.Persistence
{
    public class UsersContextTest : IDisposable
    {
        private readonly UsersContext _sut;
        private readonly DateTime _dateTime;
        private readonly Mock<IDateTime> _dateTimeMock;

        public UsersContextTest()
        {
            _dateTime = new DateTime(3001, 1, 1);
            _dateTimeMock = new Mock<IDateTime>();
            _dateTimeMock.Setup(m => m.Now).Returns(_dateTime);

            var options = new DbContextOptionsBuilder<UsersContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _sut = new UsersContext(options, _dateTimeMock.Object);

            _sut.Users.Add(new Domain.Entities.User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Brown",
                Email = "John.b@gmail.com",
                UserName = "John.b",
                PasswordHash = "12345"
            });
            _sut.SaveChanges();
        }

        [Fact]
        public async Task SaveChangesAsync_GivenNewUser_ShouldSetCreatedProperties()
        {
            var user = new User
            {
                Id = 2,
                FirstName = "Marc",
                LastName = "Junt",
                Email = "Marc.j@gmail.com",
                UserName = "Marc.j",
                PasswordHash = "123456"
            };
            _sut.Users.Add(user);

            await _sut.SaveChangesAsync();
            user.Created.ShouldBe(_dateTime);
            //user.CreatedBy.ShouldBe(_userId);
        }

        [Fact]
        public async Task SaveChangesAsync_GivenExistingUser_ShouldSetLastModifiedProperties()
        {
            var user = await _sut.Users.FindAsync(1);

            user.Email = "xxxx@gmail.com";
            
            await _sut.SaveChangesAsync();

            user.LastModified.ShouldNotBeNull();
            user.LastModified.ShouldBe(_dateTime);
            //user.LastModifiedBy.ShouldBe(_userId);
        }


        public void Dispose()
        {
            _sut?.Dispose();
        }
    }
}
