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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SampleConfiguration());
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
