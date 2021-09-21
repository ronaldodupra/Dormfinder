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
    public class UserOrganizationConfiguration : IEntityTypeConfiguration<UserOrganization>
    {
        public void Configure(EntityTypeBuilder<UserOrganization> builder)
        {
            builder.ToTable("userorganization");
            builder.HasKey(t => t.Id);

            builder.HasBaseEntityProperties();
        }
    }
}
