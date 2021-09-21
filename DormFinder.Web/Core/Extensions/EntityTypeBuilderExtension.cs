using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormFinder.Web.Core.Extensions
{
    public static class EntityTypeBuilderExtension
    {
        public static void HasBaseEntityProperties<T>(this EntityTypeBuilder<T> builder) where T : class, IBaseEntity
        {
            builder.Property(t => t.CreatedAt)
                .HasColumnType("timestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP()")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.UpdatedAt)
                .HasColumnType("timestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP()")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
