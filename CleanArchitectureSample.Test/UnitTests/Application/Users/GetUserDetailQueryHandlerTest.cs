using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureSample.Test.UnitTests.Application.Common;
using Xunit;

namespace CleanArchitectureSample.Test.UnitTests.Application.Users
{
    public class GetUserDetailQueryHandlerTest : ContextHandleTestBase
    {
        private readonly GetUserDetailQueryHandler getUserDetailQueryHandler;

        public GetUserDetailQueryHandlerTest() : base()
        {
            getUserDetailQueryHandler = new GetUserDetailQueryHandler(usersContext, mapper);
        }

        [Fact]
        public async Task GetUserDetail()
        {
            var result = await getUserDetailQueryHandler.Handle(new GetUserDetailQuery {Id = 5 }, CancellationToken.None);

            result.ShouldBeOfType<UserDetailVm>();
            result.Id.ShouldBe(5);
        }


        [Fact]
        public async Task GivenInvalidId_ThrowsNotFoundException()
        {
            var invalidId = 20;

            var command = new GetUserDetailQuery { Id = invalidId };

            await Assert.ThrowsAsync<NotFoundException>(() => getUserDetailQueryHandler.Handle(command, CancellationToken.None));
        }
    }
}
