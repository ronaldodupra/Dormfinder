using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.ToTable("building");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).HasMaxLength(255);

            builder.HasOne(t => t.Address)
                .WithMany()
                .HasForeignKey(t => t.AddressId);

            builder.HasBaseEntityProperties();
        }
    }
}
