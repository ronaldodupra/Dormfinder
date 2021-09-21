using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Services.Intefaces
{
    public interface IContractRepository
    {
        //Task<Contract> AddContract(string _companyId, Contract _contract);

        //Task UpdateContract(int _contractId, Contract _contract);

        Task Create(int companyId, Contract contract);

        Task UpdateContract();

        Task<Contract> GetById(int id);

        Task<Contract> RenewContract(string _copiedContractId, Contract _contract);

        Task<Contract> GetContract(string _contractId);
        Task<PaginatedList<Contract>> List(PageOptions _options,int orgId,DateTime _beginDate, DateTime _endDate);

        Task UpdateChecklist(string _contractId, ContractCheckList contractChecklist);

        Task UpdateDeposits(string _contractId, ContractDeposit contractDeposit);

        Task<IEnumerable<Contract>> ListByRoom(int Id);

        Task RemoveContractCharge(int id);
        Task SaveChanges();
    }
}
