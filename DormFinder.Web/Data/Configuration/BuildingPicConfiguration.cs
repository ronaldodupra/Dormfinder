using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class BuildingPicConfiguration : IEntityTypeConfiguration<BuildingPic>
    {
        public void Configure(EntityTypeBuilder<BuildingPic> builder)
        {
            builder.ToTable("buildingpic");

            builder.HasKey(t => t.Id);

            builder.HasBaseEntityProperties();
        }
    }
}
