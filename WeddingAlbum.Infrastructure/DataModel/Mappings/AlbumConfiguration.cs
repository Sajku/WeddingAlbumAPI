using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeddingAlbum.Domain.Albums;

namespace WeddingAlbum.Infrastructure.DataModel.Mappings
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Album");
            builder.HasKey(a => a.Id);

            builder
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(a => a.Photo)
                .WithMany()
                .HasForeignKey(a => a.MainPhotoId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(a => a.Event)
                .WithMany()
                .HasForeignKey(a => a.EventId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(a => a.MainPhotoId)
                .IsRequired(false);

        }
    }
}
