using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DormFinder.Web.Core.Extensions;

namespace DormFinder.Web.Data.Configuration
{
    public class BillingPeriodConfiguration : IEntityTypeConfiguration<BillingPeriod>
    {
        public void Configure(EntityTypeBuilder<BillingPeriod> builder)
        {
            builder.HasBaseEntityProperties();
        }
    }
}
