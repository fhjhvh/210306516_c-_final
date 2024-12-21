using System;

namespace BillPaymentSystem
{
    
    public abstract class Bill
    {
        
        protected string BillId { get; set; }
        protected string CustomerName { get; set; }
        protected DateTime DueDate { get; set; }

       
        public abstract decimal CalculateTotalAmount();
        public abstract string GetBillId();
        public abstract string GetCustomerName();
        public abstract DateTime GetDueDate();
        public abstract void SetBillId(string BillId);
        public abstract void SetCustomerName(string CustomerName);
        public abstract void SetDueDate(DateTime DueDate);
    }
}