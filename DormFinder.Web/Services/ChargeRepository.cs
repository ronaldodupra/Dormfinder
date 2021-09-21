using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Data;
using DormFinder.Web.Entities;
using DormFinder.Web.Models;
using DormFinder.Web.Services.Intefaces;
using System.Data;
using Microsoft.EntityFrameworkCore;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Core.Extensions;

namespace DormFinder.Web.Services
{
    public class ChargeRepository : Repository, IChargeRepository
    {
        public ChargeRepository(DormFinderContext context) : base(context)
        {
        }

        public async Task Create(Charge charge)
        {
            _context.Charges.Add(charge);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeOrder(List<ChargeOrder> _chargeOrders)
        {
            throw new System.NotImplementedException();
            //foreach (var chargeOrder in _chargeOrders)
            //{
            //    var filter = Builders<Charge>.Filter.Eq(charge => charge.InternalId, ObjectId.Parse(chargeOrder.InternalId));
            //    var updateCharge = Builders<Charge>.Update
            //    .Set(charge => charge.BillingStatementOrder, chargeOrder.Order);
            //    await _context.Charges.UpdateOneAsync(filter, updateCharge);
            //}
        }

        public async Task<Charge> GetById(int id)
        {
            return await _context.Charges.FindAsync(id);
        }

        public async Task<PaginatedList<Charge>> GetCharges(PageOptions options, int orgId)
        {
            var query = _context.Charges
                .Include(x => x.ChargeType)
                .Where(x => x.OrganizationId == orgId)
                .AsQueryable();

            query = options.Sort switch
            {
                "defaultCharge" => query.OrderBy(t => t.DefaultCharge, options.Direction),
                "billingStatementOrder" => query.OrderBy(t => t.BillingStatementOrder, options.Direction),
                "isVat" => query.OrderBy(t => t.IsVat, options.Direction),
                "comments" => query.OrderBy(t => t.Comments, options.Direction),
                _ => query
            };

            var charges = await query
                .Page(options)
                .ToListAsync();

            var total = await query.CountAsync();

            return new PaginatedList<Charge>(charges, total);
        }

        public async Task<IEnumerable<Charge>> GetChargesByCompany(string _companyId)
        {
            //throw new System.NotImplementedException();

            //_companyId = "5b6161c0c825b8601374a11f";

            //var companyId = int.Parse(_companyId);

            //var chargeId = _context.Companies.Where(c => c.Id == companyId).FirstOrDefault().ChargeIds;
            //return await _context.Charges.Where(charge => charge.Id == chargeId)
            //.OrderBy(charge => charge.BillingStatementOrder).ToListAsync();
            return null;
        }

        public Task<IEnumerable<Charge>> GetChargesByContract()
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveCharge(string _id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateCharge(int _id, Charge _charge)
        {
            throw new System.NotImplementedException();
            //var filter = Builders<Charge>.Filter.Eq(charge => charge.InternalId, ObjectId.Parse(_id));
            //var updateCharge = Builders<Charge>.Update
            //.Set(charge => charge.Name, _charge.Name)
            //.Set(charge => charge.Description, _charge.Description)
            //.Set(charge => charge.DefaultCharge, _charge.DefaultCharge)
            //.Set(charge => charge.IsVat, _charge.IsVat)
            //.CurrentDate(charge => charge.UpdatedAt);

            //UpdateResult actionResult = await _context.Charges.UpdateOneAsync(filter, updateCharge);
            //return actionResult.ModifiedCount > 0 && actionResult.IsAcknowledged;

            //_context.Entry(_charge).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            //return true;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
