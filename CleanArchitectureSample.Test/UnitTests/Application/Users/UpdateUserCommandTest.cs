using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureSample.Application.Common.Exceptions;
using CleanArchitectureSample.Application.Users.Commands.UpdateUser;
using CleanArchitectureSample.Test.UnitTests.Application.Common;
using Xunit;

namespace CleanArchitectureSample.Test.UnitTests.Application.Users
{
    public class UpdateUserCommandTest : ContextHandleTestBase
    {
        private readonly UpdateUserCommandHandler updateUserCommandHandler;

        public UpdateUserCommandTest() : base()
        {
            updateUserCommandHandler = new UpdateUserCommandHandler(usersContext);
        }

        [Fact]
        public async Task GivenInvalidId_ThrowsNotFoundException()
        {
            var invalidId = 25;
            var command = new UpdateUserCommand { Id = invalidId };

            await Assert.ThrowsAsync<NotFoundException>(() => updateUserCommandHandler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task GivenValidId_DeleteUser()
        {
            var validId = 5;
            var command = new UpdateUserCommand { Id = validId };

            await updateUserCommandHandler.Handle(command, CancellationToken.None);

            var user = await usersContext.Users.FindAsync(validId);
            Assert.Null(user);
        }
    }
}
