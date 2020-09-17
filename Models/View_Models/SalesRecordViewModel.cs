using System.Collections.Generic;
using WebApp.Models.Enums;

namespace WebApp.Models.View_Models
{
    public class SalesRecordViewModel
    {
        public ICollection<Seller> Sellers { get; set; }

        public SalesRecord SalesRecord { get; set; }

        public SaleStatus SaleStatus {get; set;}

    }
}