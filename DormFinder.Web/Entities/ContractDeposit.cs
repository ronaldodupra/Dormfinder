using System.Collections.Generic;

namespace DormFinder.Web.Entities
{
    public class ContractDeposit : BaseEntity
    {
        public int Id { get; private set; }
        public double ReservationFee { get; set; }

        public double EarlyTerminationFee { get; set; }

        public double RfidDeposit { get; set; }

        public double SecurityDeposit { get; set; }

        public List<RentalPdc> RentalPdcs { get; set; } = new List<RentalPdc>();
    }
}
