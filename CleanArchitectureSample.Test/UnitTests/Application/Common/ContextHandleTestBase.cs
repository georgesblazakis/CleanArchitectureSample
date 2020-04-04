using System;
using AutoMapper;
using CleanArchitectureSample.Application.Common.Mappings;
using CleanArchitectureSample.Infrastructure.Database;

namespace CleanArchitectureSample.Test.UnitTests.Application.Common
{
    public class ContextHandleTestBase : IDisposable
    {
        protected UsersContext usersContext;
        protected IMapper mapper;

        public ContextHandleTestBase()
        {
            usersContext = UsersContextBuilder.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            mapper = configurationProvider.CreateMapper();
        }
        public void Dispose()
        {
            UsersContextBuilder.Delete(usersContext);
        }
    }
}
