    using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureSample.Application.Common.Interfaces;
using CleanArchitectureSample.Domain.Common;
using CleanArchitectureSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Infrastructure.Database
{
    public class UsersContext : DbContext, IUsersContext
    {
        //private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;


        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
        }

        public UsersContext(
            DbContextOptions<UsersContext> options
            //ICurrentUserService currentUserService
            ,IDateTime dateTime
            ) : base(options)
        {
            _dateTime = dateTime;
            //_currentUserService = currentUserService;
        }

        public DbSet<User> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = null;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = null;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersContext).Assembly);
        }


    }
}
