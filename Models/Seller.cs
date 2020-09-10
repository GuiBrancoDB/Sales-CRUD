using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models {
    public class Seller {
        public int Id { get; set; }
        [Display(Name="Nome")]
        
        [Required(ErrorMessage="Nome é obrigatório")]
        [StringLength(80,MinimumLength=10,ErrorMessage="Nome menor que {2} caracteres, verificar novamente!")]
        public string Name { get; set; }

        [Required(ErrorMessage="Email não pode ser vazio")]
        public string Email { get; set; }
        
        [Required(ErrorMessage="Adicionar uma data de nasicmento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name="Nascimento")]
        public DateTime BirthDate { get; set; }
        
        [Required(ErrorMessage="Adicione um salário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name="Salário")]
        public double BaseSalary { get; set; }
        [Display(Name="Departamento")]
        public Department Department{ get; set; }

        public int DepartmentId{ get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() 
        {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department) 
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void addSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void removeSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
