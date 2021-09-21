using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("contract");

            builder.Property(t => t.Id);

            builder.Property(t => t.EarlyTerminationFee)
                .HasColumnType("decimal(15,4)");

            builder.Property(t => t.SecurityDeposit)
                .HasColumnType("decimal(15,4)");

            builder.Property(t => t.RFIDDeposit)
                .HasColumnType("decimal(15,4)");

            builder.Property(t => t.BasicRent)
                .HasColumnType("decimal(15,4)");

            builder.HasBaseEntityProperties();
        }
    }
}
