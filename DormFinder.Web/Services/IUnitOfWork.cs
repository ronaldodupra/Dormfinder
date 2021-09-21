using System.Threading.Tasks;
using DormFinder.Web.Services.Intefaces;

namespace DormFinder.Web.Services
{
    public interface IUnitOfWork
    {
        IBuildingRepository Buildings { get; }

        IChargeRepository Charges { get; }

        IContractRepository Contracts { get; }

        IFileEntryRepository FileEntries { get; }

        IInclusionRepository Inclusions { get; }

        ILeadRepository Leads { get; }

        IOrganizationRepository Organizations { get; }

        IPropertyRepository Properties { get; }

        IRoomRepository Rooms { get; }

        IRoomTypeRepository RoomTypes { get; }

        ITenantRepository Tenants { get; }

        Task SaveChanges();
    }
}
