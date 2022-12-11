using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.Domain.UserFavouriteAlbums;
using WeddingAlbum.Domain.UserInEvents;

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
