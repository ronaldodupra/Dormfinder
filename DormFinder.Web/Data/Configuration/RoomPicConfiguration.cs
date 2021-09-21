using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class RoomPicConfiguration : IEntityTypeConfiguration<RoomPic>
    {
        public void Configure(EntityTypeBuilder<RoomPic> builder)
        {
            builder.ToTable("roompic");

            builder.HasOne(t => t.FileEntry)
                .WithMany().HasForeignKey(t => t.FileEntryId);

            builder.HasBaseEntityProperties();
        }
    }
}
