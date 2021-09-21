using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class RoomInclusionConfiguration : IEntityTypeConfiguration<RoomInclusion>
    {
        public void Configure(EntityTypeBuilder<RoomInclusion> builder)
        {
            builder.ToTable("roominclusion");

            builder.HasOne(t => t.Inclusion)
                .WithMany()
                .HasForeignKey(t => t.InclusionId);
        }
    }
}
