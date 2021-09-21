using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class UtilityConfiguration : IEntityTypeConfiguration<Utility>
    {
        public void Configure(EntityTypeBuilder<Utility> builder)
        {
            builder.ToTable("utility");

            builder.HasKey(t => t.Id);

            builder.HasBaseEntityProperties();
        }
    }
}
