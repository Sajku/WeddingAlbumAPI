using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeddingAlbum.Domain.UserFavouriteAlbums;

namespace WeddingAlbum.Infrastructure.DataModel.Mappings
{
    public class UserFavouriteAlbumConfiguration : IEntityTypeConfiguration<UserFavouriteAlbum>
    {
        public void Configure(EntityTypeBuilder<UserFavouriteAlbum> builder)
        {
            builder.ToTable("UserFavouriteAlbum");
            builder.HasKey(u => u.Id);

            builder
                .HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(u => u.Album)
                .WithMany()
                .HasForeignKey(u => u.AlbumId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
