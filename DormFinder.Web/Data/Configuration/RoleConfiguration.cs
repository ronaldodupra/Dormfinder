using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("role");

            builder.Property(t => t.Id);

            builder.HasBaseEntityProperties();
        }
    }
}
