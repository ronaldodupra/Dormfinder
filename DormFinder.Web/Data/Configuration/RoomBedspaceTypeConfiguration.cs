using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class RoomBedspaceTypeConfiguration : IEntityTypeConfiguration<RoomBedspaceType>
    {
        public void Configure(EntityTypeBuilder<RoomBedspaceType> builder)
        {
            builder.ToTable("roombedspacetype");
        }
    }
}
