using System;
using System.Threading;
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
            
            // Act
            var result = createUserCommandHandler.Handle(new CreateUserCommand { Id = newCustomerId }, CancellationToken.None);

            // Assert
            mediatorMock.Verify(m => m.Publish(It.Is<CustomerCreated>(cc => cc.CustomerId == newCustomerId), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
