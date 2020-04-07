using System;
using System.Threading;
using CleanArchitectureSample.Application.User.Commands.CreateUser;
using CleanArchitectureSample.Test.UnitTests.Application.Common;
using MediatR;
using Moq;
using Xunit;

namespace CleanArchitectureSample.Test.UnitTests.Application.Users
{
    public class CreateUserCommandTest : ContextHandleTestBase
    {
        private readonly CreateUserCommandHandler createUserCommandHandler;
        private readonly Mock<IMediator> mediatorMock;

        public CreateUserCommandTest() : base()
        {
            mediatorMock = new Mock<IMediator>();
            createUserCommandHandler = new CreateUserCommandHandler(usersContext, mediatorMock.Object);
        }

        [Fact]
        public void GivenValidRequest_ShouldRaiseUserCreatedNotification()
        {
            // Arrange
            //var mediatorMock = new Mock<IMediator>();
            //var userCommand = new CreateUserCommandHandler(usersContext, mediatorMock.Object);
            var newUserId = 11;
            
            // Act
            var result = createUserCommandHandler.Handle(new CreateUserCommand { Id = newUserId }, CancellationToken.None);

            // Assert
            mediatorMock.Verify(m => m.Publish(It.Is<UserCreated>(cc => cc.CustomerId == newUserId), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
