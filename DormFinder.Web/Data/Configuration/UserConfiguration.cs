using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.Property(t => t.Student)
                .HasColumnType("tinyint(1)");

            builder.HasBaseEntityProperties();
        }
    }
}
