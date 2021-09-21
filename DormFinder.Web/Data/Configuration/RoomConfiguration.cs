using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("room");

            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.RoomType)
                .WithMany()
                .HasForeignKey(t => t.Type);

            builder.Property(t => t.BasicRent)
                .HasColumnType("decimal(15,4)");

            builder.Property(t => t.Area)
                .HasColumnType("decimal(10,6)");

            builder.Property(t => t.SecurityDeposit)
                .HasColumnType("decimal(15,4)");

            builder.HasBaseEntityProperties();
        }
    }
}
