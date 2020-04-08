using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureSample.Application.Common.Exceptions;
using CleanArchitectureSample.Application.Users.Commands.DeleteUser;
using CleanArchitectureSample.Test.UnitTests.Application.Common;
using Xunit;

namespace CleanArchitectureSample.Test.UnitTests.Application.Users
{
    public class DeleteUserCommantTest : ContextHandleTestBase
    {
        private readonly DeleteUserCommandHandler deleteUserCommandHandler;

        public DeleteUserCommantTest() : base()
        {
            deleteUserCommandHandler = new DeleteUserCommandHandler(usersContext);
        }

        [Fact]
        public async Task GivenInvalidId_ThrowsNotFoundException()
        {
            var invalidId = 20;
            var command = new DeleteUserCommand { Id = invalidId };

            await Assert.ThrowsAsync<NotFoundException>(() => deleteUserCommandHandler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task GivenValidId_DeleteUser()
        {
            var validId = 5;
            var command = new DeleteUserCommand { Id = validId };

            await deleteUserCommandHandler.Handle(command, CancellationToken.None);

            var user = await usersContext.Users.FindAsync(validId);
            Assert.Null(user);
        }
    }
}
