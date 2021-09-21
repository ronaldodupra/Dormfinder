using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class BedspaceConfiguration : IEntityTypeConfiguration<Bedspace>
    {
        public void Configure(EntityTypeBuilder<Bedspace> builder)
        {
            builder.ToTable("bedspace");

            builder.HasKey(t => t.Id);
            builder.Property(x => x.Status)
                .HasComment("1=Available,2=Hold,3=Reserved,4=Rented");

            builder.HasBaseEntityProperties();
        }
    }
}
