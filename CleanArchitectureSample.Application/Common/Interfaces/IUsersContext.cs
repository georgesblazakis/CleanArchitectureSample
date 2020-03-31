using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Application.Common.Interfaces
{
    public interface IUsersContext
    {
        public DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
