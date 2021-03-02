using System.Collections.Generic;
using System;
using System.Linq;


namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department() 
        { 
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {

            Sellers.Add(seller);
        }

        public double TotalSales( DateTime initial,DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final)); //Usa Expressão Lambda pega cada vendedor da lista (seller)
                                                                             //com suas vendas totais, e após soma todas as vendas de todos os vendedores (Sellers)

        }

    }

   

}
