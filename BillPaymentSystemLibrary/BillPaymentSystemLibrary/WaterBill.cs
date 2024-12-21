using BillPaymentSystem;
using System;

namespace BillPaymentSystemLibrary
{
    
    public class WaterBill : Bill
    {
        private decimal UnitCost { get; set; }
        private int UnitsConsumed { get; set; }

       
        public override decimal CalculateTotalAmount()
        {
            return UnitCost * UnitsConsumed;
        }
        public override string GetBillId()
        {
            return BillId;
        }
        public override string GetCustomerName()
        {
            return CustomerName;
        }
        public override DateTime GetDueDate()
        {
            return DueDate;
        }
        public override void SetBillId(string BillId)
        {
            this.BillId = BillId;
        }
        public override void SetCustomerName(string CustomerName)
        {
            this.CustomerName = CustomerName;
        }
        public override void SetDueDate(DateTime DueDate)
        {
            this.DueDate = DueDate;
        }
        public decimal GetUnitCost()
        {
            return UnitCost;
        }
        public void SetUnitCost(decimal UnitCost)
        {
            this.UnitCost = UnitCost;
        }
        public int GetUnitsConsumed()
        {
            return UnitsConsumed;
        }
        public void SetUnitsConsumed(int UnitsConsumed)
        {
            this.UnitsConsumed = UnitsConsumed;
        }
    }
}
