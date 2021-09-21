using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class AmenityConfiguration : IEntityTypeConfiguration<Amenity>
    {
        public void Configure(EntityTypeBuilder<Amenity> builder)
        {
            builder.ToTable("amenity");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Description)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasBaseEntityProperties();
        }
    }
}
