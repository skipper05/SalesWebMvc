using System;
using System.Collections.Generic; //Permite a utilização de IColections (um vendedor (seler) tem uma ou mais vendas (SalesRecord)  
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Display (Name = "Birth Date")] //PAra colocar os titulos no formato desejado. Ex: Birth Date Separado 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] //Para colocar Data padrao brasileiro
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salary")] //PAra colocar os titulos no formato desejado. Ex: Birth Date Separado 
        [DisplayFormat(DataFormatString = "{0:F2}")] //Para colocar dinheiro na forma .00
        public double BaseSalary { get; set; }
        public Department Department { get; set; }

        public int DepartmentId { get; set; } //Avisa para o Entity framework que esse ID deve exist

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() 
        {
        }

        public Seller(int Id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            this.Id = Id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            this.BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales (SalesRecord sr)
        {
            Sales.Add(sr);

        }
        public void RemoveSales (SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final) //Usando linq - em uma linha soma-se total vendas vendedor em um intervalo de datas
        {
        return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);

        }
    



    }


}
