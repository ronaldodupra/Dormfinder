using System;
using AutoMapper;
using DormFinder.Web.Charges.Models;

namespace DormFinder.Web.Entities
{
    public class Charge : BaseEntity
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public string Comments { get; set; }

        public decimal DefaultCharge { get; set; }

        public int BillingStatementOrder { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public bool IsVat { get; set; }

        public int ChargeTypeId { get; set; }

        public ChargeType ChargeType { get; set; }
    }
}
