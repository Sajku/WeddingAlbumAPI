using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeddingAlbum.Domain.PhotoInAlbums;

namespace WeddingAlbum.Infrastructure.DataModel.Mappings
{
    public class PhotoInAlbumConfiguration : IEntityTypeConfiguration<PhotoInAlbum>
    {
        public void Configure(EntityTypeBuilder<PhotoInAlbum> builder)
        {
            builder.ToTable("PhotoInAlbum");
            builder.HasKey(p => p.Id);

            builder
                .HasOne(p => p.Album)
                .WithMany()
                .HasForeignKey(p => p.AlbumId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(p => p.Photo)
                .WithMany()
                .HasForeignKey(p => p.PhotoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
