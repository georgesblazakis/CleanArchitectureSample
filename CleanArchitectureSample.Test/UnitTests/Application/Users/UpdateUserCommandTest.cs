using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureSample.Application.Common.Exceptions;
using CleanArchitectureSample.Application.Users.Commands.UpdateUser;
using CleanArchitectureSample.Test.UnitTests.Application.Common;
using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitectureSample.Test.UnitTests.Application.Users
{
    public class UpdateUserCommandTest : ContextHandleTestBase
    {
        private readonly UpdateUserCommandHandler updateUserCommandHandler;
        private readonly Mock<IMediator> mediatorMock;

        public UpdateUserCommandTest() : base()
        {
            mediatorMock = new Mock<IMediator>();
            updateUserCommandHandler = new UpdateUserCommandHandler(usersContext, mediatorMock.Object, mapper);
        }

        [Fact]
        public async Task GivenInvalidId_ThrowsNotFoundException()
        {
            var invalidId = 25;
            var command = new UpdateUserCommand { Id = invalidId, FirstName = "Louis", LastName = "Blaz", Email = "Louis.b@gmail.com", UserName = "Louis.b", PasswordHash = "12345678" };
                
            await Assert.ThrowsAsync<NotFoundException>(() => updateUserCommandHandler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task GivenValidId_UpdateUser()
        {
            var validId = 5;
            var command = new UpdateUserCommand { Id = validId, FirstName = "Louis", LastName = "Blaz", Email = "Louis.b@gmail.com", UserName = "Louis.b", PasswordHash = "12345678" };

            await updateUserCommandHandler.Handle(command, CancellationToken.None);

            var result = await usersContext.Users.FindAsync(validId);
            result.FirstName.ShouldBe(command.FirstName);
            result.LastName.ShouldBe(command.LastName);
            mediatorMock.Verify(m => m.Publish(It.Is<UserUpdatedNotification>(userCreated => userCreated.UserId == result.Id), It.IsAny<CancellationToken>()), Times.Once);

        }
    }
}
