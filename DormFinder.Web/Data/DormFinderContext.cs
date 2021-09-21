using DormFinder.Web.Entities;
using DormFinder.Web.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DormFinder.Web.Data
{
    public class DormFinderContext
        : IdentityDbContext<
            User,
            Role,
            int,
            UserClaim,
            UserRole,
            UserLogin,
            RoleClaim,
            UserToken>
    {
        public DbSet<Address> Address { get; set; }

        public DbSet<Bedspace> Bedspaces { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<BuildingType> BuildingTypes { get; set; }

        public DbSet<Charge> Charges { get; set; }

        public DbSet<ChargeType> ChargeTypes { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<ContractCharge> ContractCharges { get; set; }

        public DbSet<FileEntry> FileEntries { get; set; }

        public DbSet<Inclusion> Inclusions { get; set; }

        public DbSet<Lead> Leads { get; set; }

        public DbSet<Province> Provinces { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Room> Room { get; set; }

        public DbSet<RoomBedspaceType> RoomBedspaceTypes { get; set; }

        public DbSet<RoomInclusion> RoomInclusions { get; set; }

        public DbSet<RoomPic> RoomPics { get; set; }

        public DbSet<UserOrganization> UserOrganizations { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<BuildingNearbyPlace> BuildingNearbyPlace { get; set; }

        public DbSet<BillingPeriod> BillingPeriod { get; set; }
        public DbSet<UtilityReading> UtilityReadings { get; set; }

        public DbSet<Utility> Utilities { get; set; }


        public DormFinderContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DormFinderContext).Assembly);
        }
    }
}
