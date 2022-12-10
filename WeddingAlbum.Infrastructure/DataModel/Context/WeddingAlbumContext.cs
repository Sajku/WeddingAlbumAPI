using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WeddingAlbum.Common.Auth;
using WeddingAlbum.Domain.Common;
using WeddingAlbum.Domain.Samples;
using WeddingAlbum.Infrastructure.DataModel.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WeddingAlbum.Domain.Users;
using WeddingAlbum.Domain.Photos;
using WeddingAlbum.Domain.Events;

namespace WeddingAlbum.Infrastructure.DataModel.Context
{
    public class WeddingAlbumContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public WeddingAlbumContext() { }

        public WeddingAlbumContext(DbContextOptions<WeddingAlbumContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Sample> Samples { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SampleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new PhotoConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"));
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = _currentUserService.UserId;
                        entry.Entity.UpdatedOn = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
