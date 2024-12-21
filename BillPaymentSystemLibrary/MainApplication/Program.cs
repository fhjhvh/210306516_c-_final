using System;
using BillPaymentSystem;
using BillPaymentSystemLibrary;

class Program
{
    static void Main(string[] args)
    {
        
        ElectricityBill electricityBill = new ElectricityBill();
        electricityBill.SetBillId("EB001");
        electricityBill.SetCustomerName("Ahmed Ali");
        electricityBill.SetDueDate(new DateTime(2024, 12, 30));
        electricityBill.SetUnitCost(0.5m);
        electricityBill.SetUnitsConsumed(300);

        WaterBill waterBill = new WaterBill();
        waterBill.SetBillId("WB001");
        waterBill.SetCustomerName("Sara Mohamed");
        waterBill.SetDueDate(new DateTime(2024, 12, 25));
        waterBill.SetUnitCost(0.2m);
        waterBill.SetUnitsConsumed(500);

        InternetBill internetBill = new InternetBill();
        internetBill.SetBillId("IB001");
        internetBill.SetCustomerName("Mohamed Khaled");
        internetBill.SetDueDate(new DateTime(2024, 12, 20));
        internetBill.SetMonthlyCost(30.0m);

       
        PrintBillDetails(electricityBill);
        PrintBillDetails(waterBill);
        PrintBillDetails(internetBill);
        Console.ReadLine();


    }

  
    static void PrintBillDetails(Bill bill)
    {
        Console.WriteLine($"Bill ID: {bill.GetBillId()}");
        Console.WriteLine($"Customer: {bill.GetCustomerName()}");
        Console.WriteLine($"Due Date: {bill.GetDueDate().ToShortDateString()}");
        Console.WriteLine($"Total Amount: {bill.CalculateTotalAmount()}");
        Console.WriteLine();
    }
}
