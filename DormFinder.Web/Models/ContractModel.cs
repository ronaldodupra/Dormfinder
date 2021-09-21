using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using DormFinder.Web.Charges.Models;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Models
{
    public class AddContractModel
    {
        public int? Id { get; set; }

        public DateTime RentalEffectivityDate { get; set; }

        public DateTime? RentalEndDate { get; set; }

        public DateTime? MoveInDate { get; set; }

        public DateTime? MoveOutDate { get; set; }

        public DateTime? ReservationStartDate { get; set; }

        public DateTime? ReservationExpirationDate { get; set; }

        public int? AllowableReservationDays { get; set; }

        public double? EarlyTerminationFee { get; set; }

        //public Tenant Tenant { get; set; }

        public int RoomId { get; set; }

        public Unit Unit { get; set; }

        public UnitBedspace Bedspace { get; set; }

        public double BasicRent { get; set; }

        public string Status { get; set; }

        public ContractDeposit ContractDeposit { get; set; }

        public string tenantName { get; set; }

        public string UnitNumber { get; set; }

        public string BedSpaceNumber { get; set; }

        public double SecurityDeposit { get; set; }

        public double RFIDDeposit { get; set; }

        public string UtilitiesElectricity { get; set; }

        public string UtilitiesWater { get; set; }

        public int UserId { get; set; }

        public int LeadId { get; set; }

        public bool Approve { get; set; }

        public ICollection<int> ContractCharge { get; set; }


    }

    public class Unit
    {
        public string internalId { get; set; }

        public string unitNumber { get; set; }
    }

    //public class Tenant
    //{
    //    public string internalId { get; set; }
    //    public string fullName { get; set; }
    //}

    public class UnitBedspace
    {
        public string internalId { get; set; }

        public string bedspaceNumber { get; set; }
    }

    public class UpdateContractModel
    {
        // public int? Id { get; set; }
        public DateTime RentalEffectivityDate { get; set; }

        public DateTime? RentalEndDate { get; set; }

        public DateTime? MoveInDate { get; set; }

        public DateTime? MoveOutDate { get; set; }

        public DateTime? ReservationStartDate { get; set; }

        public DateTime? ReservationExpirationDate { get; set; }

        public int? AllowableReservationDays { get; set; }

        public double? EarlyTerminationFee { get; set; }

        //public Tenant Tenant { get; set; }

        public Unit Unit { get; set; }

        public UnitBedspace Bedspace { get; set; }

        public double BasicRent { get; set; }

        public string Status { get; set; }

        public ContractDeposit ContractDeposit { get; set; }

        public string tenantName { get; set; }

        public string UnitNumber { get; set; }

        public string BedSpaceNumber { get; set; }

        public double SecurityDeposit { get; set; }

        public double RFIDDeposit { get; set; }

        public string UtilitiesElectricity { get; set; }

        public string UtilitiesWater { get; set; }

        public int LeadId { get; set; }

        public ICollection<int> ContractCharge { get; set; }

        public bool Approve { get; set; }

        //public int Id { get; set; }
        //public DateTime RentalEffectivityDate { get; set; }
        //public DateTime RentalEndDate { get; set; }
        //public DateTime MoveInDate { get; set; }
        //public DateTime MoveOutDate { get; set; }
        //public DateTime ReservationStartDate { get; set; }
        //public DateTime ReservationExpirationDate { get; set; }
        //public int AllowableReservationDays { get; set; }
        //public double Price { get; set; }
    }

    public class ContractCheckLists
    {
        public int? StudentId { get; set; }

        public string ParentId { get; set; }

        public string ParentIdType { get; set; }
    }

    public class ContractModel
    {
        public int Id { get; set; }

        public DateTime RentalEffectivityDate { get; set; }

        public DateTime? RentalEndDate { get; set; }

        public DateTime? MoveInDate { get; set; }

        public DateTime? MoveOutDate { get; set; }

        public DateTime? ReservationStartDate { get; set; }

        public DateTime? ReservationExpirationDate { get; set; }

        public int? AllowableReservationDays { get; set; }

        public double? EarlyTerminationFee { get; set; }

        public string tenantName { get; set; }

        public int RoomId { get; set; }

        public string UnitNumber { get; set; }

        public string BedSpaceNumber { get; set; }

        public double SecurityDeposit { get; set; }

        public double RFIDDeposit { get; set; }

        public string UtilitiesElectricity { get; set; }

        public string UtilitiesWater { get; set; }

        public double BasicRent { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int UserId { get; set; }
        public TenantDto Tenant { get; set; }

        public ICollection<ContractChargeDto> ContractCharge { get; set; }

        public bool Approve { get; set; }
        
        public class ContractChargeDto
        {
            public ChargeDto Charge { get; set; }
        }
    }

    public class UpdateDepositModel
    {
        //public int? Id { get; set; }
        public double ReservationFee { get; set; }
    }

    public class ChecklisttModel
    {
        public int? StudentId { get; set; }
    }

}
