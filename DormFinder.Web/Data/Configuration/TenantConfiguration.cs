using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.ToTable("tenant");

            builder.HasKey(t => t.Id);

            builder.HasBaseEntityProperties();

            builder.HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId);

            builder.HasOne(t => t.Contract)
                .WithOne(t => t.Tenant)
                .HasForeignKey<Tenant>(t => t.ContractId);

            builder.HasOne(t => t.Room)
                .WithMany()
                .HasForeignKey(t => t.RoomId);
        }
    }
}
