using System;
using WebApp.Models.Enums;

namespace WebApp.Models{
    public class SalesRecord {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }

        public int SellerId { get; set; }

        public SalesRecord() 
        {

        }

        public SalesRecord(int id, DateTime time, double amount, SaleStatus status, Seller seller) 
        {
            Id = id;
            Date = time;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }

}
