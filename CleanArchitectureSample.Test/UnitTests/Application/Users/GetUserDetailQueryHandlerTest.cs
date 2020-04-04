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
    }
}
