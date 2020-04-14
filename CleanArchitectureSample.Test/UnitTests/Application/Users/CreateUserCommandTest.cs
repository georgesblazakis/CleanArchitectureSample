using System;
using System.Threading;
using AutoMapper;
using CleanArchitectureSample.Application.Users.Commands.CreateUser;
using CleanArchitectureSample.Test.UnitTests.Application.Common;
using MediatR;
using Moq;
using Xunit;

namespace CleanArchitectureSample.Test.UnitTests.Application.Users
{
    public class CreateUserCommandTest : ContextHandleTestBase
    {
        //private readonly CreateUserCommandHandler createUserCommandHandler;
        //private readonly Mock<IMediator> mediatorMock;

        //public CreateUserCommandTest() : base()
        //{
        //    mediatorMock = new Mock<IMediator>();

        //}

        [Fact]
        public void GivenValidRequest_ShouldRaiseUserCreatedNotification()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var createUserCommandHandler = new CreateUserCommandHandler(usersContext, mediatorMock.Object, mapper);

            var userCommand = new CreateUserCommand() {
                Id = 11,
                FirstName = "Peter",
                LastName = "Jun",
                Email = "Peter.j@gmail.com",
                UserName = "Peter.j",
                PasswordHash = "123456"
            };
            // Act
            var result = createUserCommandHandler.Handle(userCommand, CancellationToken.None);

            // Assert
            mediatorMock.Verify(m => m.Publish(It.Is<UserCreatedNotification>(userCreated => userCreated.UserId == userCommand.Id), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
