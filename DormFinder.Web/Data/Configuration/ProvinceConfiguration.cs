using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("province");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Description)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasBaseEntityProperties();
        }
    }
}
