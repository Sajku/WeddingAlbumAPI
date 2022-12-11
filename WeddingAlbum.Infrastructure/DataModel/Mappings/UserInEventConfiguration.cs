using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.Domain.Events;
using WeddingAlbum.Domain.UserInEvents;

namespace WeddingAlbum.Infrastructure.DataModel.Mappings
{
    public class UserInEventConfiguration : IEntityTypeConfiguration<UserInEvent>
    {
        public void Configure(EntityTypeBuilder<UserInEvent> builder)
        {
            builder.ToTable("UserInEvent");
            builder.HasKey(u => u.Id);

            builder
                .HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(u => u.Event)
                .WithMany()
                .HasForeignKey(u => u.EventId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
