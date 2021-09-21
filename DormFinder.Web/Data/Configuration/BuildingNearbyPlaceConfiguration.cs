using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
   
    public class BuildingNearbyPlaceConfiguration : IEntityTypeConfiguration<BuildingNearbyPlace>
    {
        public void Configure(EntityTypeBuilder<BuildingNearbyPlace> builder)
        {
        }
    }
}
