using System;

namespace WebTSJ.Models
{
    public class ReceiptModel
    {
        public int Id { get; set; }
        public string IdBill { get; set; }
        public DateTime BillDate { get; set; }
        public int Amount { get; set; }
        public int Debt { get; set; }
        public int Balance { get; set; }

        public ReceiptModel(string idBill, DateTime billDate, int amount, int debt, int balance)
        {
            IdBill = idBill;
            BillDate = billDate;
            Amount = amount;
            Debt = debt;
            Balance = balance;
        }
        
        public ReceiptModel(int id, string idBill, DateTime billDate, int amount, int debt, int balance)
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