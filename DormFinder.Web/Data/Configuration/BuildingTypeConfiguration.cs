using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class BuildingTypeConfiguration : IEntityTypeConfiguration<BuildingType>
    {
        public void Configure(EntityTypeBuilder<BuildingType> builder)
        {
            builder.ToTable("buildingtype");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Description)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasBaseEntityProperties();
        }
    }
}
