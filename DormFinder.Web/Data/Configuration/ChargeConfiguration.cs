using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class ChargeConfiguration : IEntityTypeConfiguration<Charge>
    {
        public void Configure(EntityTypeBuilder<Charge> builder)
        {
            builder.ToTable("charge");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.DefaultCharge)
                .HasColumnType("decimal(15,4)");

            builder.Property(t => t.Amount)
                .HasColumnType("decimal(15,4)");

            builder.Property(t => t.Comments)
                .HasColumnType("text");

            builder.Property(t => t.Date)
                .HasColumnType("date");

            builder.HasBaseEntityProperties();
        }
    }
}
