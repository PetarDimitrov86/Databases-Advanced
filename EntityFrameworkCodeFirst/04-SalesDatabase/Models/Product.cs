using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _04_SalesDatabase.Models
{
    public class Product
    {
        public Product()
        {
            SalesOfProduct = new HashSet<Sale>();
        }

        [Key]
        public int ProductId { get; set; }

        [MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        [Range(0, Int32.MaxValue)]
        public double Quantity { get; set; }

        [Range(1, (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        public ICollection<Sale> SalesOfProduct { get; set; }
    }
}