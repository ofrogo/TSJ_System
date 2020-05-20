using System;

namespace Entities
{
    public class Receipt
    {
        public int Id { get; set; }
        public string IdBill { get; set; }
        public DateTime BillDate { get; set; }
        public int Amount { get; set; }
        public int Debt { get; set; }
        public int Balance { get; set; }

        public Receipt(string idBill, DateTime billDate, int amount, int debt, int balance)
        {
            IdBill = idBill;
            BillDate = billDate;
            Amount = amount;
            Debt = debt;
            Balance = balance;
        }
        
        public Receipt(int id, string idBill, DateTime billDate, int amount, int debt, int balance)
        {
            Id = id;
            IdBill = idBill;
            BillDate = billDate;
            Amount = amount;
            Debt = debt;
            Balance = balance;
        }
    }
}