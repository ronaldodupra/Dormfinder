

using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class ChargeTypeConfiguration : IEntityTypeConfiguration<ChargeType>
    {
        public void Configure(EntityTypeBuilder<ChargeType> builder)
        {
            builder.ToTable("chargetype");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Description)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.DefaultAmount)
                .HasColumnType("decimal(15,4)");
            
            builder.HasBaseEntityProperties();
        }
    }
}
