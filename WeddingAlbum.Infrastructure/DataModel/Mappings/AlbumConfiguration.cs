using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeddingAlbum.Domain.Album;

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
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(a => a.Photo)
                .WithMany()
                .HasForeignKey(a => a.MainPhotoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(a => a.Event)
                .WithMany()
                .HasForeignKey(a => a.EventId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
