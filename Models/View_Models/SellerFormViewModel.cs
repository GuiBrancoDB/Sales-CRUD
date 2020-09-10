using System.Collections.Generic;

namespace WebApp.Models.View_Models

{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }

        
    }
}