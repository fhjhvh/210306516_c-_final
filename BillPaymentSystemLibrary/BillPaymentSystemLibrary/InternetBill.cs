using BillPaymentSystem;
using System;

namespace BillPaymentSystemLibrary
{
    
    public class InternetBill : Bill
    {
        private decimal MonthlyCost { get; set; }

        
        public override decimal CalculateTotalAmount()
        {
            return MonthlyCost;
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
        public decimal GetMonthlyCost()
        {
            return MonthlyCost;
        }
        public void SetMonthlyCost(decimal MonthlyCost)
        {
            this.MonthlyCost = MonthlyCost;
        }
    }
}
