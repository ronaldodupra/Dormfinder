using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class ContractChargeConfiguration : IEntityTypeConfiguration<ContractCharge>
    {
        public void Configure(EntityTypeBuilder<ContractCharge> builder)
        {
            builder.ToTable("contractcharge");
        }
    }
}
