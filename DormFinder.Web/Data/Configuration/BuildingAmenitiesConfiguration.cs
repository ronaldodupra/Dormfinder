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
    public class BuildingAmenitiesConfiguration: IEntityTypeConfiguration<BuildingAmenity>
    {
        public void Configure(EntityTypeBuilder<BuildingAmenity> builder)
        {
            builder.HasBaseEntityProperties();
            builder.HasOne(t => t.Amenity)
                .WithMany()
                .HasForeignKey(t => t.AmenityId);
        }
    }
}
