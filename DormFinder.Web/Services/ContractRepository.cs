using System.Collections.Generic;
using System.Threading.Tasks;
using DormFinder.Web.Data;
using DormFinder.Web.Core.Paging;
using System.Linq;
using DormFinder.Web.Entities;
using DormFinder.Web.Services.Intefaces;
using Microsoft.EntityFrameworkCore;
using DormFinder.Web.Core.Extensions;
using System;

namespace DormFinder.Web.Services
{
    public class ContractRepository : Repository, IContractRepository
    {
        public ContractRepository(DormFinderContext context) : base(context)
        {
        }

        public async Task Create(int companyId, Contract contract)
        {

            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();
            // _companyId = "5b6161c0c825b8601374a11f";
            // await _context.Contracts.InsertOneAsync(_contract);
            // await _context.Companies.FindOneAndUpdateAsync(
            //    company => company.InternalId == ObjectId.Parse(_companyId),
            //    Builders<Company>.Update.AddToSet(company => company.ContractIds, _contract.InternalId)
            //);
            //await _context.Bedspaces.FindOneAndUpdateAsync(
            //    bedspace => bedspace.InternalId == ObjectId.Parse(_contract.Bedspace.internalId),
            //    Builders<Bedspace>.Update.Set(bedspace => bedspace.Status, "reserved"));
            // await _context.Contacts.FindOneAndUpdateAsync(
            //     contact => contact.InternalId == ObjectId.Parse(_contract.Tenant.internalId),
            //     Builders<Contact>.Update.Set(contact => contact.Status, "reserved tenant"));
            // return _contract;
        }

        public async Task<Contract> GetContract(string _contractId)
        {
            throw new System.NotImplementedException();
            //return await _context.Contracts.Find(contract => contract.InternalId == ObjectId.Parse(_contractId)).FirstOrDefaultAsync();
        }

        public async Task<PaginatedList<Contract>> List(PageOptions options, int orgId, DateTime beginDate, DateTime endDate)
        {

            var query = _context.Contracts
                .Where(c => c.OrganizationId == orgId
                && (c.RentalEffectivityDate.Date <= endDate.Date && (c.RentalEndDate.Value.Date >= beginDate.Date) || c.RentalEndDate.Value.Date == null && c.RentalEffectivityDate.Date <= endDate.Date)).AsQueryable();
            //        .Where(t => t.tenantName);
            query = options.Sort switch
            {
                "tenantName" => query.OrderBy(t => t.TenantName, options.Direction),
                "lease" => query.OrderBy(t => t.RentalEffectivityDate, options.Direction),
                "allowableReservationDays" => query.OrderBy(t => t.AllowableReservationDays, options.Direction),
                "status" => query.OrderBy(t => t.Status, options.Direction),
                _ => query
            };
            var contracts = await query
                .Page(options)
                .ToListAsync();

            var total = await query.CountAsync();

            return new PaginatedList<Contract>(contracts, total);
         
        }

        public async Task<Contract> RenewContract(string _compiedContractId, Contract _contract)
        {
            return _contract;
        }

        public async Task UpdateChecklist(string _contractId, ContractCheckList contractChecklist)
        {
            throw new System.NotImplementedException();


            //_context.checkLists.Add(contractChecklist);
            //await _context.SaveChangesAsync();


            //var filter = Builders<Contract>.Filter.Eq(contract => contract.InternalId, ObjectId.Parse(_contractId));
            //var update = Builders<Contract>.Update
            //.Set(contract => contract.ContractCheckList, _contractChecklist)
            //.CurrentDate(contract => contract.UpdatedAt);
            //var actionResult = await _context.Contracts.UpdateOneAsync(filter, update);
            //return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }

        public async Task UpdateContract()
        {
            //_context.Contracts.Update(contract);
            await _context.SaveChangesAsync();
            //var contract = await _repository.Getcontractid(_contractId);

            //_mapper.Map(_contract, contract);

            //foreach (var amenityDescription in _contract.Amenities)
            //{
            //    contract.AddAmenity(amenityDescription);
            //}

            //await _repository.SaveChanges();

            //return _mapper.Map<UpdateContractModel>(contract);




          //  throw new System.NotImplementedException();
            //var filter = Builders<Contract>.Filter.Eq(contract => contract.InternalId, ObjectId.Parse(_contractId));
            //var updateContract = Builders<Contract>.Update
            //.Set(contract => contract.Id, _contract.Id)
            //.Set(contract => contract.RentalEffectivityDate, _contract.RentalEffectivityDate)
            //.Set(contract => contract.RentalEndDate, _contract.RentalEndDate)
            //.Set(contract => contract.MoveInDate, _contract.MoveInDate)
            //.Set(contract => contract.MoveOutDate, _contract.MoveOutDate)
            //.Set(contract => contract.ReservationStartDate, _contract.ReservationStartDate)
            //.Set(contract => contract.ReservationExpirationDate, _contract.ReservationExpirationDate)
            //.Set(contract => contract.AllowableReservationDays, _contract.AllowableReservationDays)
            //// .Set(contract => contract.Tenant, _contract.Tenant)
            //// .Set(contract => contract.Unit, _contract.Unit)
            //// .Set(contract => contract.Bedspace, _contract.Bedspace)
            //.Set(contract => contract.Price, _contract.Price)
            //.CurrentDate(contract => contract.UpdatedAt);

            //var actionResult = await _context.Contracts.UpdateOneAsync(filter, updateContract);
            //return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }

        public async Task UpdateDeposits(string _contractId, ContractDeposit _contractDeposit)
        {
            throw new System.NotImplementedException();
            //var filter = Builders<Contract>.Filter.Eq(contract => contract.InternalId, ObjectId.Parse(_contractId));
            //var update = Builders<Contract>.Update.Set(contract => contract.ContractDeposit, _contractDeposit)
            //.CurrentDate(contract => contract.UpdatedAt);
            //var actionResult = await _context.Contracts.UpdateOneAsync(filter, update);
            //return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }

        public async Task<Contract> GetById(int id)
        {
            return await _context.Contracts
                .Include(t => t.ContractCharge)
                        .ThenInclude(it => it.Charge)
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Contract>> ListByRoom(int id)
        {
            return await _context.Contracts.Include(x=>x.Tenant)
                .Where(t => t.RoomId== id)
                .ToListAsync();
        }

        public async Task RemoveContractCharge(int id)
        {
            var contractCharges = _context.ContractCharges.Where(x => x.ContractId == id).ToList();
            _context.ContractCharges.RemoveRange(contractCharges);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}


















































//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using DormFinder.Web.Data;
//using DormFinder.Web.Entities;
//using DormFinder.Web.Services.Intefaces;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;

//namespace DormFinder.Web.Services
//{
//    public class ContractRepository : Repository, IContractRepository
//    {
//        public ContractRepository(DormFinderContext context) : base(context)
//        {
//        }


//        public async Task Create(string companyId, Contract contract)
//        {
//            _context.Contracts.Add(contract);
//            await _context.SaveChangesAsync();

//           // throw new System.NotImplementedException();
//            // _companyId = "5b6161c0c825b8601374a11f";
//            // await _context.Contracts.InsertOneAsync(_contract);
//            // await _context.Companies.FindOneAndUpdateAsync(
//            //    company => company.InternalId == ObjectId.Parse(_companyId),
//            //    Builders<Company>.Update.AddToSet(company => company.ContractIds, _contract.InternalId)
//            //);
//            //await _context.Bedspaces.FindOneAndUpdateAsync(
//            //    bedspace => bedspace.InternalId == ObjectId.Parse(_contract.Bedspace.internalId),
//            //    Builders<Bedspace>.Update.Set(bedspace => bedspace.Status, "reserved"));
//            // await _context.Contacts.FindOneAndUpdateAsync(
//            //     contact => contact.InternalId == ObjectId.Parse(_contract.Tenant.internalId),
//            //     Builders<Contact>.Update.Set(contact => contact.Status, "reserved tenant"));
//            // return _contract;
//        }

//        public async Task<Contract> GetContract(string _contractId)
//        {
//            throw new System.NotImplementedException();
//            //return await _context.Contracts.Find(contract => contract.InternalId == ObjectId.Parse(_contractId)).FirstOrDefaultAsync();
//        }

//        public async Task<IEnumerable<Contract>> GetContracts(string _companyId)
//        {
//            throw new System.NotImplementedException();
//            //_companyId = "5b6161c0c825b8601374a11f";
//            //var selCompany = await _context.Companies.Find(company => company.InternalId == ObjectId.Parse(_companyId)).FirstOrDefaultAsync();
//            //var contractFilter = Builders<Contract>.Filter.In(contract => contract.InternalId, selCompany.ContractIds);
//            //return await _context.Contracts.Find(contractFilter).ToListAsync();
//        }

//        public async Task<Contract> RenewContract(string _compiedContractId, Contract _contract)
//        {
//            return _contract;
//        }

//        public async Task<bool> UpdateChecklist(string _contractId, ContractCheckList _contractChecklist)
//        {
//            throw new System.NotImplementedException();
//            //var filter = Builders<Contract>.Filter.Eq(contract => contract.InternalId, ObjectId.Parse(_contractId));
//            //var update = Builders<Contract>.Update
//            //.Set(contract => contract.ContractCheckList, _contractChecklist)
//            //.CurrentDate(contract => contract.UpdatedAt);
//            //var actionResult = await _context.Contracts.UpdateOneAsync(filter, update);
//            //return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
//        }

//        public async Task UpdateContract(int _contractId, Contract _contract)
//        {

//            _context.Contracts.Update(_contract);
//            await _context.SaveChangesAsync();





//            //throw new System.NotImplementedException();
//            //var filter = Builders<Contract>.Filter.Eq(contract => contract.InternalId, ObjectId.Parse(_contractId));
//            //var updateContract = Builders<Contract>.Update
//            //.Set(contract => contract.Id, _contract.Id)
//            //.Set(contract => contract.RentalEffectivityDate, _contract.RentalEffectivityDate)
//            //.Set(contract => contract.RentalEndDate, _contract.RentalEndDate)
//            //.Set(contract => contract.MoveInDate, _contract.MoveInDate)
//            //.Set(contract => contract.MoveOutDate, _contract.MoveOutDate)
//            //.Set(contract => contract.ReservationStartDate, _contract.ReservationStartDate)
//            //.Set(contract => contract.ReservationExpirationDate, _contract.ReservationExpirationDate)
//            //.Set(contract => contract.AllowableReservationDays, _contract.AllowableReservationDays)
//            //// .Set(contract => contract.Tenant, _contract.Tenant)
//            //// .Set(contract => contract.Unit, _contract.Unit)
//            //// .Set(contract => contract.Bedspace, _contract.Bedspace)
//            //.Set(contract => contract.Price, _contract.Price)
//            //.CurrentDate(contract => contract.UpdatedAt);

//            //var actionResult = await _context.Contracts.UpdateOneAsync(filter, updateContract);
//            //return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
//        }

//        public async Task<bool> UpdateDeposits(string _contractId, ContractDeposit _contractDeposit)
//        {
//            throw new System.NotImplementedException();
//            //var filter = Builders<Contract>.Filter.Eq(contract => contract.InternalId, ObjectId.Parse(_contractId));
//            //var update = Builders<Contract>.Update.Set(contract => contract.ContractDeposit, _contractDeposit)
//            //.CurrentDate(contract => contract.UpdatedAt);
//            //var actionResult = await _context.Contracts.UpdateOneAsync(filter, update);
//            //return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
//        }

//        public async Task<Contract> GetById(int id)
//        {
//            return await _context.Contracts
//                .Where(t => t.Id == id)
//                .FirstOrDefaultAsync();
//        }
//    }
//}
