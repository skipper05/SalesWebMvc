using System;
using System.Collections.Generic; //Permite a utilização de IColections (um vendedor (seler) tem uma ou mais vendas (SalesRecord)  
using System.Linq;


namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }

        public int DepartmentId { get; set; } //Avisa para o Entity framework que esse ID deve exist

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() 
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            this.id = id;
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
