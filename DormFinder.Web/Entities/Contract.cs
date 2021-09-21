using System;
using System.Collections.Generic;

namespace DormFinder.Web.Entities
{
    public class Contract : BaseEntity
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public DateTime RentalEffectivityDate { get; set; }

        public Nullable<DateTime> RentalEndDate { get; set; }

        public DateTime? MoveInDate { get; set; }

        public DateTime? MoveOutDate { get; set; }

        public DateTime? ReservationStartDate { get; set; }

        public DateTime? ReservationExpirationDate { get; set; }

        public int? AllowableReservationDays { get; set; }

        public decimal? EarlyTerminationFee { get; set; }

        public string TenantName { get; set; }

        public string UnitNumber { get; set; }

        public string BedSpaceNumber { get; set; }

        public decimal SecurityDeposit { get; set; }

        public decimal RFIDDeposit { get; set; }

        public string UtilitiesElectricity { get; set; }

        public string UtilitiesWater { get; set; }

        public decimal BasicRent { get; set; }

        public string Status { get; set; }

        public int RoomId { get; set; }

        public int UserId { get; set; }
        public int LeadId { get; set; }

        public Room Room { get; set; }

        public Tenant Tenant { get; set; }
        public Lead Lead { get; set; }

        public bool Approve { get; set; }

        public ICollection<ContractCharge> ContractCharge { get; set; }

        public void AddContractCharge(int chargeId)
        {
            var contractCharge = new ContractCharge();
            contractCharge.ChargeId = chargeId;
            ContractCharge.Add(contractCharge);                       
        }
    }    
}
