using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class InclusionConfiguration : IEntityTypeConfiguration<Inclusion>
    {
        public void Configure(EntityTypeBuilder<Inclusion> builder)
        {
            builder.ToTable("inclusion");

            builder.HasBaseEntityProperties();
        }
    }
}
