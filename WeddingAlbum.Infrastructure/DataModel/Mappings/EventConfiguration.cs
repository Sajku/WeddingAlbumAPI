using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeddingAlbum.Domain.Events;

namespace WeddingAlbum.Infrastructure.DataModel.Mappings
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Event");
            builder.HasKey(e => e.Id);
            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.OwnerUserId)
                .IsRequired(true);
        }
    }
}
