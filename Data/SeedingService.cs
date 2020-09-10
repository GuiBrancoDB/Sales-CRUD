using System.Linq;
using WebApp.Models;
using System;
using WebApp.Models.Enums;

namespace WebApp.Data
{
    public class SeedingService
    {
        private WebAppContext _context;
        public SeedingService(WebAppContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return;
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Cellphones");
            Department d3 = new Department(3, "Eletronics");


            Seller s1 = new Seller(1, "Bob","bobbrown@gmail.com", new DateTime(1998,4,12), 1000.60, d1);
            Seller s2 = new Seller(2, "Kingsman","kng@gmail.com", new DateTime(1995,4,11), 3000.60, d1);
            Seller s3 = new Seller(3, "Lucy","lucy@gmail.com", new DateTime(1994,4,10), 6000.60, d1);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2018,9,25),11000,SaleStatus.Billed,s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2020,8,25),5000,SaleStatus.Billed,s2);

            _context.Department.AddRange(d1,d2,d3);
            _context.Seller.AddRange(s1,s2,s3);
            _context.SalesRecord.AddRange(sr1,sr2);

            _context.SaveChanges();

        }
    }
}