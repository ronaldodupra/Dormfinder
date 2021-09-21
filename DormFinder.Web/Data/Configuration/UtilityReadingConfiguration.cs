using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class UtilityReadingConfiguration : IEntityTypeConfiguration<UtilityReading>
    {
        public void Configure(EntityTypeBuilder<UtilityReading> builder)
        {
            builder.ToTable("utilityreading");

            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Utility)
                .WithMany()
                .HasForeignKey(t => t.UtilityId);

            builder.Property(t => t.Reading)
                .HasColumnType("decimal(15,4)");

            builder.HasBaseEntityProperties();
        }
    }
}
