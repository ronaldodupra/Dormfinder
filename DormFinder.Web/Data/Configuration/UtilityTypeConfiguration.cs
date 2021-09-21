using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class UtilityTypeConfiguration : IEntityTypeConfiguration<UtilityType>
    {
        public void Configure(EntityTypeBuilder<UtilityType> builder)
        {
            builder.ToTable("utilitytype");

            builder.HasKey(t => t.Id);

            builder.HasBaseEntityProperties();
        }
    }
}
