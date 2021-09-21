using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Data.Configuration
{
    public class FileEntryConfiguration : IEntityTypeConfiguration<FileEntry>
    {
        public void Configure(EntityTypeBuilder<FileEntry> builder)
        {
            builder.ToTable("fileentry");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Filename)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.MediaType)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.Path)
                .IsRequired();

            builder.HasBaseEntityProperties();
        }
    }
}
