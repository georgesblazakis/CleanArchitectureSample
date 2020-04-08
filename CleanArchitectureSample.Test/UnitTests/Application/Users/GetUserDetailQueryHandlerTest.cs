using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureSample.Application.Common.Exceptions;
using CleanArchitectureSample.Application.Users.Queries.GetUserDetail;
using CleanArchitectureSample.Test.UnitTests.Application.Common;
using Shouldly;
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
        public async Task GivenInvalidId_ThrowsNotFoundException()
        {
            var invalidId = 20;

            var command = new GetUserDetailQuery { Id = invalidId };

            await Assert.ThrowsAsync<NotFoundException>(() => getUserDetailQueryHandler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task GetUserDetail()
        {
            var result = await getUserDetailQueryHandler.Handle(new GetUserDetailQuery {Id = 5 }, CancellationToken.None);

            result.ShouldBeOfType<GetUserDetailViewModel>();
            result.Id.ShouldBe(5);
        }


        
    }
}
