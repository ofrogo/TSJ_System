using System;
using System.Collections.Generic;
using Entities;

namespace WebTSJ.Models
{
    public class JilezInfoModel
    {
        public JilezInfoModel(string idBill, DateTime billDate, int amount, int debt, int balance, Dictionary<string, int> servicesCount, Dictionary<string, int> servicePrice)
        {
            IdBill = idBill;
            BillDate = billDate;
            Amount = amount;
            Debt = debt;
            Balance = balance;
            ServicesCount = servicesCount;
            ServicePrice = servicePrice;
        }

        public string IdBill { get; set; }
        public DateTime BillDate { get; set; }
        public int Amount { get; set; }
        public int Debt { get; set; }
        public int Balance { get; set; }
        public Dictionary<string, int> ServicesCount { get; set; }
        public Dictionary<string, int> ServicePrice { get; set; }
    }
}