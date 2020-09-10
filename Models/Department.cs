using System.Collections.Generic;
using WebApp.Models;
using System;
using System.Linq;

namespace WebApp.Models
{
    public class Department
    {
        public string Departamento { get; set; }
        public int Id { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();
        public Department()
        {

        }

        public Department(int id, string departamento)
        {
            Id = id;
            Departamento = departamento;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime fianl)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, fianl));
        }

    }


}