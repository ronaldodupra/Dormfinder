using System.Threading.Tasks;
using DormFinder.Web.Data;
using DormFinder.Web.Services.Intefaces;

namespace DormFinder.Web.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DormFinderContext _context;

        public IBuildingRepository Buildings { get; }

        public IChargeRepository Charges { get; }

        public IContractRepository Contracts { get; }

        public IFileEntryRepository FileEntries { get; }

        public IInclusionRepository Inclusions { get; }

        public ILeadRepository Leads { get; }

        public IOrganizationRepository Organizations { get; }

        public IPropertyRepository Properties { get; }

        public IRoomRepository Rooms { get; }

        public IRoomTypeRepository RoomTypes { get; }

        public ITenantRepository Tenants { get; }

        public UnitOfWork(DormFinderContext context)
        {
            _context = context;

            Buildings = new BuildingRepository(context);
            Charges = new ChargeRepository(context);
            Contracts = new ContractRepository(context);
            FileEntries = new FileEntryRepository(context);
            Inclusions = new InclusionRepository(context);
            Leads = new LeadRepository(context);
            Organizations = new OrganizationRepository(context);
            Properties = new PropertyRepository(context);
            Rooms = new RoomRepository(context);
            RoomTypes = new RoomTypeRepository(context);
            Tenants = new TenantRepository(context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
