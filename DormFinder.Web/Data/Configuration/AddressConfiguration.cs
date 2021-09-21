using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("address");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Latitude)
                .HasColumnType("decimal(8,6)");

            builder.Property(t => t.Longitude)
                .HasColumnType("decimal(9,6)");

            builder.HasBaseEntityProperties();
        }
    }
}
