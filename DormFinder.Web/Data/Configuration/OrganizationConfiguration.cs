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
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("organization");
            builder.HasKey(t => t.Id);

            builder.HasBaseEntityProperties();
        }
    }
}
